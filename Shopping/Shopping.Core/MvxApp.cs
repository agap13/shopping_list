﻿// ---------------------------------------------------------------
// <author>Paul Datsyuk</author>
// <url>https://www.linkedin.com/in/pauldatsyuk/</url>
// ---------------------------------------------------------------

using Acr.UserDialogs;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Platform.IoC;
using MvvmCross.Platform.Platform;
using MvvmCross.Plugins.Json;
using Shopping.Core.Services;
using Shopping.Core.Services.Stubs;

namespace Shopping.Core
{
    public class MvxApp : MvxApplication
    {
        public static readonly bool IsConfiguredWithStubs = false;

        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            CreatableTypes().
                EndingWith("Repository")
                .AsTypes()
                .RegisterAsLazySingleton();

            Mvx.RegisterType<Services.IAppSettings, Services.AppSettings>();
            //Mvx.RegisterType<IMvxJsonConverter, MvxJsonConverter>();
            Mvx.RegisterSingleton<IUserDialogs>(() => UserDialogs.Instance);

            Mvx.LazyConstructAndRegisterSingleton<IShoppingService, ShoppingService>();

            //if (IsConfiguredWithStubs == false)
            //{
            //    //todo: add
            //}
            Resources.AppResources.Culture = Mvx.Resolve<Services.ILocalizeService>().GetCurrentCultureInfo();

            RegisterAppStart<ViewModels.MainViewModel>();
        }
    }
}
