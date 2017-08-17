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
    public class ShoppingListViewModel : MvxViewModel<ShoppingItemPO>
    {
        private readonly IShoppingService _shoppingService;
        private readonly IMvxNavigationService _navigationService;

        public ShoppingListViewModel(IMvxNavigationService navigationService, IShoppingService shoppingService)
        {
            _shoppingService = shoppingService;
            _navigationService = navigationService;

        }

        public IMvxAsyncCommand<ShoppingItemPO> RemoveItemCommand => new MvxAsyncCommand<ShoppingItemPO>(RemoveShoppingItem);

        private async Task RemoveShoppingItem(ShoppingItemPO item)
        {
            var list = await _shoppingService.DeleteShoppingItem(item); 
            ShoppingList = new MvxObservableCollection<ShoppingItemPO>(list); 
        }

        public IMvxAsyncCommand<ShoppingItemPO> EditItemCommand => new MvxAsyncCommand<ShoppingItemPO>(EditShoppingItem);

        private async Task EditShoppingItem(ShoppingItemPO arg)
        {
            //_navigationService.Navigate<ShoppingListViewModel, ShoppingItemPO>(item);
            await _navigationService.Navigate<EditShoppingItemViewModel,ShoppingItemPO>(arg);
        }

        public IMvxAsyncCommand ClearShoppingListCommand => new MvxAsyncCommand(async () => 
        {
            var list = await _shoppingService.ClearShoppingList();
            ShoppingList = new MvxObservableCollection<ShoppingItemPO>(list);
        });

        public IMvxCommand AddShoppingListItem => new MvxCommand(() => { _navigationService.Navigate<AddShoppingItemViewModel>(); });
       

        public MvxObservableCollection<ShoppingItemPO> ShoppingList { get; set; }

        private ShoppingItemPO _selectedShoppingItem;
        public ShoppingItemPO SelectedShoppingItem
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
            ShoppingList = new MvxObservableCollection<ShoppingItemPO>(list);
        }

        public override async Task Initialize(ShoppingItemPO parameter)
        {
            if (parameter == null)
                return;
            var list = await _shoppingService.AddShoppingItem(parameter);
            ShoppingList = new MvxObservableCollection<ShoppingItemPO>(list);
        }
    }
}
