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
    public class AddShoppingItemViewModel : MvxViewModel
    {
        private readonly IShoppingService _shoppingService;
        private readonly IMvxNavigationService _navigationService;

        public AddShoppingItemViewModel(IMvxNavigationService navigationService, IShoppingService shoppingService)
        {
            _shoppingService = shoppingService;
            _navigationService = navigationService;
        }

        public IMvxCommand AddShoppingItemCmd => new MvxCommand(AddNewShoppingItem);

        public ShoppingItemPO ShoppingItem { get; set; } = new ShoppingItemPO();
       
        public List<string> ItemTypes = new List<string>() { "Na wagę", "Na sztuki" };
        public string SelectedType { get; set; }

        public bool IsPerWeightItemVisible
        {
            get
            {
                if (SelectedType.Contains("Na wagę"))
                    return true;
                else
                    return false;
            }
        }

        int _counter = 0;
        public override async Task Initialize()
        {
            var list = await _shoppingService.GetShoppingList();
            _counter = list.Count;
        }

        public double AmountCounter { get; set; }
        private void AddNewShoppingItem()
        {
            //if (!IsValidPrice || !IsValidNumber)
            //{
            //    ErrorMessage = "Niepoprawna cena lub ilość!";
            //}
            //else
            {
                ShoppingItemPO item;
                if (IsPerWeightItemVisible)
                {
                    item = new ShoppingItemPerWeight();
                    (item as ShoppingItemPerWeight).ItemAmount = AmountCounter;
                }
                else
                {
                    item = new ShoppingItemPerPcs();
                    (item as ShoppingItemPerPcs).ItemCount = (int)AmountCounter; //change
                }

                item.Price = ShoppingItem.Price;
                item.Name = ShoppingItem.Name;
                item.ImgPath = "pytajnik.jpg";
                ShoppingItem.ShoppingId = _counter;

                _navigationService.Navigate<ShoppingListViewModel, ShoppingItemPO>(item);
            }
        }

        bool _isValidPrice = false;
        public bool IsValidPrice
        {
            get
            {
                return _isValidPrice;
            }
            set
            {
                if(_isValidPrice!=value)
                {
                    _isValidPrice = value;
                    RaisePropertyChanged(() =>IsValidPrice);
                }
            }
        }

        bool _isValidNumber = false;
        public bool IsValidNumber
        {
            get
            {
                return _isValidNumber;
            }
            set
            {
                if (_isValidNumber != value)
                {
                    _isValidNumber = value;
                    RaisePropertyChanged(() => IsValidNumber);
                }
            }
        }
        public string ErrorMessage { get; set; } = string.Empty;
    }
}
