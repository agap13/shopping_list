﻿using MvvmCross.Forms.Core;
using Xamarin.Forms.Xaml;

namespace Shopping.Core.Pages
{
    /// <summary>
    /// Used to display page for editing existing shopping item.
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditShoppingItemPage : MvxContentPage
    {
        public EditShoppingItemPage()
        {
            InitializeComponent();
        }
    }
}