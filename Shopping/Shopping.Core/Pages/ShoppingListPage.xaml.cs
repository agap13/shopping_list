using MvvmCross.Forms.Core;
using Xamarin.Forms.Xaml;

namespace Shopping.Core.Pages
{
    /// <summary>
    /// Page for displaying shopping list with edit/add buttons.
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShoppingListPage : MvxContentPage
    {
        public ShoppingListPage()
        {
            InitializeComponent();
        }
    }
}