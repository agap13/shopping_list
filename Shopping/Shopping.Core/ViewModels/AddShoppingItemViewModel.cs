using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using Shopping.Core.Model.Entities;
using Shopping.Core.Services;

namespace Shopping.Core.ViewModels
{
    public class AddShoppingItemViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService _navigationService;
        private readonly IShoppingService _shoppingService;

        private int _counter;

        public List<string> ItemTypes = new List<string> {"Na wagę", "Na sztuki"};

        public AddShoppingItemViewModel(IMvxNavigationService navigationService, IShoppingService shoppingService)
        {
            _shoppingService = shoppingService;
            _navigationService = navigationService;
        }

        public ShoppingItemEntity ShoppingItem { get; set; } = new ShoppingItemEntity();
        public string SelectedType { get; set; }

        public bool IsPerWeightItemVisible => SelectedType.Contains("Na wagę");

        public double AmountCounter { get; set; }

        private bool _isValidPrice;
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

        private bool _isValidNumber;
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

        public override async Task Initialize()
        {
            var list = await _shoppingService.GetShoppingList();
            _counter = list.Count;
        }

        public IMvxCommand AddShoppingItemCmd => new MvxCommand(AddNewShoppingItem);

        private void AddNewShoppingItem()
        {
            if (IsValidPrice && IsValidNumber)
            {
                ErrorMessage = String.Empty;
                ShoppingItemEntity item;
                if (IsPerWeightItemVisible)
                {
                    item = new ShoppingItemPerWeight();
                    (item as ShoppingItemPerWeight).ItemAmount = AmountCounter;
                }
                else
                {
                    item = new ShoppingItemPerPcs();
                    (item as ShoppingItemPerPcs).ItemCount = (int) AmountCounter; //change
                }

                item.Price = ShoppingItem.Price;
                item.Name = ShoppingItem.Name;
                item.ImgPath = "pytajnik.jpg";
                ShoppingItem.ShoppingId = _counter;

                _navigationService.Navigate<ShoppingListViewModel, ShoppingItemEntity>(item);
            }
            else
            {
                ErrorMessage = "Niepoprawna cena lub ilość!";
            }
        }
    }
}