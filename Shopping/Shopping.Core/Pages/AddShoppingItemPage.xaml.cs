using MvvmCross.Forms.Core;
using Xamarin.Forms.Xaml;

namespace Shopping.Core.Pages
{
    /// <summary>
    /// Display page for adding ne item.
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddShoppingItemPage : MvxContentPage
    {
        public AddShoppingItemPage()
        {
            InitializeComponent();
        }
    }
}