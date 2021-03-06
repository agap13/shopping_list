﻿using Acr.UserDialogs;
using Android.App;
using Android.Content.PM;
using Android.OS;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Views;
using MvvmCross.Forms.Droid;
using MvvmCross.Forms.Presenters;
using MvvmCross.Platform;
using Xamarin.Forms;

namespace Shopping.Droid
{
    [Activity(Label = "FormsApplicationActivity", ScreenOrientation = ScreenOrientation.Portrait)]
    public class FormsApplicationActivity : MvxFormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            Forms.Init(this, bundle);

            UserDialogs.Init(this);

            var formsPresenter = (MvxFormsPagePresenter)Mvx.Resolve<IMvxAndroidViewPresenter>();
            LoadApplication(formsPresenter.FormsApplication);

            Mvx.Resolve<IMvxAppStart>().Start();
        }
    }
}