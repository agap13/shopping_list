using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using Shopping.Core.POs;
using Shopping.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Core.ViewModels
{
    public class EditShoppingItemViewModel : MvxViewModel<ShoppingItemPO>
    {
        private readonly IShoppingService _shoppingService;
        private readonly IMvxNavigationService _navigationService;

        public EditShoppingItemViewModel(IMvxNavigationService navigationService, IShoppingService shoppingService)
        {
            _shoppingService = shoppingService;
            _navigationService = navigationService;
        }

        public ShoppingItemPO ShoppingItem { get; set; }

        public override async Task Initialize(ShoppingItemPO parameter)
        {
            await Task.Run(()=>ShoppingItem = parameter);
            AmountCounter = (ShoppingItem is ShoppingItemPerPcs) ? (ShoppingItem as ShoppingItemPerPcs).ItemCount : (ShoppingItem as ShoppingItemPerWeight).ItemAmount;
        }

        public double AmountCounter { get; set; }

        public bool IsValidPrice { get; set; }

        public bool IsValidNumber { get; set; }

        public string ErrorMessage { get; set; } = string.Empty;

        public IMvxAsyncCommand EditShoppingItemCmd => new MvxAsyncCommand(EditShoppingItem);

        private async Task EditShoppingItem()
        {
            //if (!IsValidPrice || !IsValidNumber)
            //{
            //    ErrorMessage = "Niepoprawna cena lub ilość!";
            //}
            //else
            {
                if(ShoppingItem is ShoppingItemPerPcs)
                {
                    (ShoppingItem as ShoppingItemPerPcs).ItemCount = (int)AmountCounter;
                }
                else
                {
                    (ShoppingItem as ShoppingItemPerWeight).ItemAmount = AmountCounter;
                }
                await _shoppingService.EditShoppingItem(ShoppingItem);
                await _navigationService.Navigate<ShoppingListViewModel>();
            }
        }
    }
}
