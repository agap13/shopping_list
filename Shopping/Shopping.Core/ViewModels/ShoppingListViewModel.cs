using System.Linq;
using System.Threading.Tasks;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using Shopping.Core.Model.Entities;
using Shopping.Core.Services;

namespace Shopping.Core.ViewModels
{
    /// <summary>
    /// View Model for displaying shopping list items.
    /// </summary>
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

        /// <summary>
        /// Execute when clear button is clicked.
        /// </summary>
        public IMvxAsyncCommand ClearShoppingListCommand => new MvxAsyncCommand(async () =>
        {
            await _shoppingService.ClearShoppingList();
            UpdateCollection();
        });

        /// <summary>
        /// Used when add  button is clicked.
        /// </summary>
        public IMvxCommand AddShoppingListItem => new MvxCommand(() =>
        {
            _navigationService.Navigate<AddShoppingItemViewModel>();
        });

        /// <summary>
        /// Used to store list with shopping item entries.
        /// </summary>
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

        /// <summary>
        /// Execute when remove item icon is clicked.
        /// </summary>
        public IMvxAsyncCommand<ShoppingItemEntity> RemoveItemCommand =>
            new MvxAsyncCommand<ShoppingItemEntity>(RemoveShoppingItem);

        private async Task RemoveShoppingItem(ShoppingItemEntity item)
        {
            await _shoppingService.DeleteShoppingItem(item);
            UpdateCollection();
        }

        /// <summary>
        /// Execute when edit item icon is clicked.
        /// </summary>
        public IMvxAsyncCommand<ShoppingItemEntity> EditItemCommand =>
            new MvxAsyncCommand<ShoppingItemEntity>(EditShoppingItem);

        private async Task EditShoppingItem(ShoppingItemEntity arg)
        {
            await _navigationService.Navigate<EditShoppingItemViewModel, ShoppingItemEntity>(arg);
            UpdateCollection();
        }

        /// <summary>
        /// Used to store total price.
        /// </summary>
        public double PriceSum { get; set; }

        public override async Task Initialize()
        {
            var list = await _shoppingService.GetShoppingList();

            // insert data to database just for displaying some items when api was started
            if (list.Count == 0)
            {
                await _shoppingService.InitDatabase();
            }
            list = await _shoppingService.GetShoppingList();
            ShoppingList = new MvxObservableCollection<ShoppingItemEntity>(list);
            CalculateSum();
        }

        private void CalculateSum()
        {
            PriceSum = 0;
            foreach (var item in ShoppingList )
            {
                if (item is ShoppingItemPerPcs)
                {
                    PriceSum += item.Price * (item as ShoppingItemPerPcs).ItemCount;
                }
                else
                {
                    PriceSum += item.Price * (item as ShoppingItemPerWeight).ItemAmount;
                }
            }
        }

        /// <summary>
        /// Call from AddShoppingItemViewModel or EditShoppingItemViewModel.
        /// </summary>
        /// <param name="parameter">ShoppingItemEntity obtain from AddShoppingItemViewModel or EditShoppingItemViewModel.</param>
        /// <returns>Return task.</returns>
        public override async Task Initialize(ShoppingItemEntity parameter)
        {
            if (parameter == null)
            {
                return;
            }

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