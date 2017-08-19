using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using Shopping.Core.POs;
using Shopping.Core.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Core.ViewModels
{
    public class ShoppingListViewModel : MvxViewModel<ShoppingItemEntity>
    {
        private readonly IShoppingService _shoppingService;
        private readonly IMvxNavigationService _navigationService;

        public ShoppingListViewModel(IMvxNavigationService navigationService, IShoppingService shoppingService)
        {
            _shoppingService = shoppingService;
            _navigationService = navigationService;
        }

        public IMvxAsyncCommand<ShoppingItemEntity> RemoveItemCommand => new MvxAsyncCommand<ShoppingItemEntity>(RemoveShoppingItem);

        private async Task RemoveShoppingItem(ShoppingItemEntity item)
        {
            await _shoppingService.DeleteShoppingItem(item);
            UpdateCollection();
        }

        public IMvxAsyncCommand<ShoppingItemEntity> EditItemCommand => new MvxAsyncCommand<ShoppingItemEntity>(EditShoppingItem);

        private async Task EditShoppingItem(ShoppingItemEntity arg)
        {
            await _navigationService.Navigate<EditShoppingItemViewModel,ShoppingItemEntity>(arg);
            UpdateCollection();
        }

        public IMvxAsyncCommand ClearShoppingListCommand => new MvxAsyncCommand(async () => 
        {
            await _shoppingService.ClearShoppingList();
            UpdateCollection();
        });

        public IMvxCommand AddShoppingListItem => new MvxCommand(() => { _navigationService.Navigate<AddShoppingItemViewModel>(); });
       

        public MvxObservableCollection<ShoppingItemEntity> ShoppingList { get; set; }

        private ShoppingItemEntity _selectedShoppingItem;
        public ShoppingItemEntity SelectedShoppingItem
        {
            get
            {
                return _selectedShoppingItem;
            }
            set
            {
                if(_selectedShoppingItem!= value)
                {
                    _selectedShoppingItem = value;
                    RaisePropertyChanged(() => SelectedShoppingItem);
                }
            }
        }


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
        }
    }
}
