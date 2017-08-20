using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;

namespace Shopping.Core.ViewModels
{

    /// <summary>
    /// Main View Model
    /// </summary>
    public class MainViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService _navigationService;

        public MainViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public IMvxCommand GoToSecondPageCommand => new MvxCommand(DisplayShoppingListAction);

        private void DisplayShoppingListAction()
        {
            _navigationService.Navigate<ShoppingListViewModel>();
        }
    }
}