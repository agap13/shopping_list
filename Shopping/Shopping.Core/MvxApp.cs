using Acr.UserDialogs;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Platform.IoC;
using Shopping.Core.Model.Storage;
using Shopping.Core.Model.Storage.Interfaces;
using Shopping.Core.Resources;
using Shopping.Core.Services;
using Shopping.Core.ViewModels;

namespace Shopping.Core
{
    public class MvxApp : MvxApplication
    {
        // set to true to test stub service 
        public static readonly bool IsConfiguredWithStubs = false; 

        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            CreatableTypes().EndingWith("Repository")
                .AsTypes()
                .RegisterAsLazySingleton();

            Mvx.RegisterType<IAppSettings, AppSettings>();
            Mvx.RegisterSingleton(() => UserDialogs.Instance);

            if (IsConfiguredWithStubs)
                CreatableTypes()
                    .EndingWith("Stub")
                    .AsInterfaces()
                    .RegisterAsLazySingleton();

            Mvx.LazyConstructAndRegisterSingleton<IGenericStorage, GenericStorage>();
            AppResources.Culture = Mvx.Resolve<ILocalizeService>().GetCurrentCultureInfo();

            RegisterAppStart<MainViewModel>();
        }
    }
}