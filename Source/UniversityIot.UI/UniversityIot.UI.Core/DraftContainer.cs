using UniversityIot.UI.Core.DataAccess;
using UniversityIot.UI.Core.Models;
using UniversityIot.UI.Core.MVVM;
using UniversityIot.UI.Core.ViewModels;
using UniversityIot.UI.Core.Views;

namespace UniversityIot.UI.Core
{
    public static class DraftContainer
    {
        public static NavigationService NavigationService { get; private set; }
        public static IDatapointsRepository DatapointsRepository { get; private set; }

        static DraftContainer()
        {
            var viewViewModelRegister = new ViewViewModelRegister();
            NavigationService = new NavigationService(App.Current.MainPage.Navigation, viewViewModelRegister);
            DatapointsRepository = new DatapointsRepository();

            RegisterViewModels(viewViewModelRegister);
        }

        private static void RegisterViewModels(ViewViewModelRegister viewViewModelRegister)
        {
            viewViewModelRegister.Register<InstallationPage, InstallationViewModel>();
            viewViewModelRegister.Register<LoginPage, LoginViewModel>();
        }
    }
}