using System;
using System.Threading.Tasks;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using Shopping.Core.Model.Entities;
using Shopping.Core.Services;

namespace Shopping.Core.ViewModels
{
    public class EditShoppingItemViewModel : MvxViewModel<ShoppingItemEntity>
    {
        private readonly IMvxNavigationService _navigationService;
        private readonly IShoppingService _shoppingService;

        public EditShoppingItemViewModel(IMvxNavigationService navigationService, IShoppingService shoppingService)
        {
            _shoppingService = shoppingService;
            _navigationService = navigationService;
        }

        public ShoppingItemEntity ShoppingItem { get; set; }

        public double AmountCounter { get; set; }

        private bool _isValidPrice = true;
        public bool IsValidPrice
        {
            get => _isValidPrice;
            set
            {
                if (_isValidPrice != value)
                {
                    _isValidPrice = value;
                    ErrorMessage = string.Empty;
                    RaisePropertyChanged(() => IsValidPrice);
                }
            }
        }

        private bool _isValidNumber = true;
        public bool IsValidNumber
        {
            get => _isValidNumber;
            set
            {
                if (_isValidNumber != value)
                {
                    _isValidNumber = value;
                    ErrorMessage = string.Empty;
                    RaisePropertyChanged(() => IsValidNumber);
                }
            }
        }

        public string ErrorMessage { get; set; } = string.Empty;

        public override async Task Initialize(ShoppingItemEntity parameter)
        {
            await Task.Run(() => ShoppingItem = parameter);
            AmountCounter = ShoppingItem is ShoppingItemPerPcs
                ? (ShoppingItem as ShoppingItemPerPcs).ItemCount
                : (ShoppingItem as ShoppingItemPerWeight).ItemAmount;
        }

        public IMvxAsyncCommand EditShoppingItemCmd => new MvxAsyncCommand(EditShoppingItem);

        private async Task EditShoppingItem()
        {
            if (IsValidPrice && IsValidNumber)
            {
                ErrorMessage = string.Empty;
                if (ShoppingItem is ShoppingItemPerPcs)
                    (ShoppingItem as ShoppingItemPerPcs).ItemCount = (int) AmountCounter;
                else
                    (ShoppingItem as ShoppingItemPerWeight).ItemAmount = AmountCounter;
                await _shoppingService.EditShoppingItem(ShoppingItem);
                await _navigationService.Navigate<ShoppingListViewModel>();
            }
            else
            {
                ErrorMessage = "Niepoprawna cena lub ilość!";
            }
        }
    }
}