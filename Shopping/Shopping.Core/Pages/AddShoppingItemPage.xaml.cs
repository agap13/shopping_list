using MvvmCross.Forms.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Shopping.Core.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddShoppingItemPage : MvxContentPage
    {
        public AddShoppingItemPage()
        {
            InitializeComponent();
        }
    }
}