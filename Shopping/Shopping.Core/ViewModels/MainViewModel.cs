// ---------------------------------------------------------------
// <author>Paul Datsyuk</author>
// <url>https://www.linkedin.com/in/pauldatsyuk/</url>
// ---------------------------------------------------------------

using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using System.Collections.Generic;
using Xamarin.Forms;
using System;

namespace Shopping.Core.ViewModels
{
    public class MainViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService _navigationService;
        private readonly Services.IAppSettings _settings;

        public MainViewModel(IMvxNavigationService navigationService, Services.IAppSettings settings)
        {
            _navigationService = navigationService;
            _settings = settings;

           
        }

        public IMvxCommand GoToSecondPageCommand => new MvxCommand(DisplayShoppingListAction);

        private void DisplayShoppingListAction()
        {
            _navigationService.Navigate<ShoppingListViewModel>();
        }

        //public IMvxCommand OpenGithubUrlCommand =>
        //    new MvxCommand(() =>
        //    {
        //        Device.OpenUri(new Uri("https://github.com/JTOne123/XamFormsMvxTemplate"));
        //    });

        public string ButtonText { get; set; }
    }
}