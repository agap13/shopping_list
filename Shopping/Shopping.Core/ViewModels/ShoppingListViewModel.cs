using System.Linq;
using System.Threading.Tasks;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using Shopping.Core.Model.Entities;
using Shopping.Core.Services;

namespace Shopping.Core.ViewModels
{
    public class ShoppingListViewModel : MvxViewModel<ShoppingItemEntity>
    {
        private readonly IMvxNavigationService _navigationService;
        private readonly IShoppingService _shoppingService;

        private ShoppingItemEntity _selectedShoppingItem;

        public ShoppingListViewModel(IMvxNavigationService navigationService, IShoppingService shoppingService)
        {
            _shoppingService = shoppingService;
            _navigationService = navigationService;
        }

        public IMvxAsyncCommand ClearShoppingListCommand => new MvxAsyncCommand(async () =>
        {
            await _shoppingService.ClearShoppingList();
            UpdateCollection();
        });

        public IMvxCommand AddShoppingListItem => new MvxCommand(() =>
        {
            _navigationService.Navigate<AddShoppingItemViewModel>();
        });


        public MvxObservableCollection<ShoppingItemEntity> ShoppingList { get; set; } = new MvxObservableCollection<ShoppingItemEntity>();

        public ShoppingItemEntity SelectedShoppingItem
        {
            get => _selectedShoppingItem;
            set
            {
                if (_selectedShoppingItem != value)
                {
                    _selectedShoppingItem = value;
                    RaisePropertyChanged(() => SelectedShoppingItem);
                }
            }
        }

        public IMvxAsyncCommand<ShoppingItemEntity> RemoveItemCommand =>
            new MvxAsyncCommand<ShoppingItemEntity>(RemoveShoppingItem);

        private async Task RemoveShoppingItem(ShoppingItemEntity item)
        {
            await _shoppingService.DeleteShoppingItem(item);
            UpdateCollection();
        }

        public IMvxAsyncCommand<ShoppingItemEntity> EditItemCommand =>
            new MvxAsyncCommand<ShoppingItemEntity>(EditShoppingItem);

        private async Task EditShoppingItem(ShoppingItemEntity arg)
        {
            await _navigationService.Navigate<EditShoppingItemViewModel, ShoppingItemEntity>(arg);
            UpdateCollection();
        }

        public double PriceSum { get; set; }
        public override async Task Initialize()
        {
            var list = await _shoppingService.GetShoppingList();

            // insert data to database just for displaying some items when api was started
            if (list.Count == 0)
                await _shoppingService.InitDatabase();
            list = await _shoppingService.GetShoppingList();
            ShoppingList = new MvxObservableCollection<ShoppingItemEntity>(list);
            CalculateSum();
        }

        private void CalculateSum()
        {
            PriceSum = ShoppingList.Select(x => x.Price).Sum();
        }
        public override async Task Initialize(ShoppingItemEntity parameter)
        {
            if (parameter == null)
                return;

            await _shoppingService.AddShoppingItem(parameter);
            UpdateCollection();
        }

        private async void UpdateCollection()
        {
            var list = await _shoppingService.GetShoppingList();

            ShoppingList.Clear();
            ShoppingList.AddRange(list);
            CalculateSum();
        }
    }
}