using UniversityIot.UI.Core.MVVM;
using UniversityIot.UI.Core.Services;
using UniversityIot.UI.Core.ViewModels;
using UniversityIot.UI.Core.Views;

namespace UniversityIot.UI.Core
{
    public static class DraftContainer
    {
        public static NavigationService NavigationService { get; private set; }

        static DraftContainer()
        {
            var viewViewModelRegister = new ViewViewModelRegister();
            NavigationService = new NavigationService(App.Current.MainPage.Navigation, viewViewModelRegister);

            RegisterViewModels(viewViewModelRegister);
        }

        private static void RegisterViewModels(ViewViewModelRegister viewViewModelRegister)
        {
            viewViewModelRegister.Register<InstallationPage, InstallationViewModel>();
            viewViewModelRegister.Register<LoginPage, LoginViewModel>();
        }
    }
}