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
    public class ShoppingListViewModel : MvxViewModel
    {
        private readonly IShoppingService _shoppingService;
        private readonly IMvxNavigationService _navigationService;



        public IMvxAsyncCommand<ShoppingItemPO> RemoveItemCommand => new MvxAsyncCommand<ShoppingItemPO>(RemoveShoppingItem);

        private async Task RemoveShoppingItem(ShoppingItemPO item)
        {
            var list = await _shoppingService.DeleteShoppingItem(item.ShoppingId); //change in service
            ShoppingList = new MvxObservableCollection<ShoppingItemPO>(list); 

        }


        public ShoppingListViewModel(IMvxNavigationService navigationService, IShoppingService shoppingService)
        {
            _shoppingService = shoppingService;
            _navigationService = navigationService;
           
        }

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
    }
}
