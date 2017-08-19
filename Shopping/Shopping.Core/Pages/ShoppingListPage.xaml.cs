using MvvmCross.Forms.Core;
using Xamarin.Forms.Xaml;

namespace Shopping.Core.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShoppingListPage : MvxContentPage
    {
        public ShoppingListPage()
        {
            InitializeComponent();
        }
    }
}