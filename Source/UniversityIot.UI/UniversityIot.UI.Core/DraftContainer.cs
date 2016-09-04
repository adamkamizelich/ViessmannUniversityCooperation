using UniversityIot.UI.Core.DataAccess;
using UniversityIot.UI.Core.DataAccess.Fakes;
using UniversityIot.UI.Core.Models;
using UniversityIot.UI.Core.MVVM;
using UniversityIot.UI.Core.Services;
using UniversityIot.UI.Core.ViewModels;
using UniversityIot.UI.Core.Views;
using Xamarin.Forms;

namespace UniversityIot.UI.Core
{
    public static class DraftContainer
    {
        public static NavigationService NavigationService { get; private set; }
        public static IDatapointsRepository DatapointsRepository { get; private set; }
        public static UserManagementService UserManagementService { get; private set; }
        public static IInstallationsRepository InstallationsRepository { get; private set; }
        public static ViewViewModelRegister ViewViewModelRegister { get; }

        static DraftContainer()
        {
            ViewViewModelRegister = new ViewViewModelRegister();
            NavigationService = new NavigationService(ViewViewModelRegister);
            DatapointsRepository = new DatapointsRestService();
            UserManagementService = new UserManagementService();
            InstallationsRepository = new InstallationsRestService();

            RegisterViewModels(ViewViewModelRegister);
        }

        private static void RegisterViewModels(ViewViewModelRegister viewViewModelRegister)
        {
            viewViewModelRegister.Register<InstallationDetailsPage, InstallationDetailsViewModel>();
            viewViewModelRegister.Register<LoginPage, LoginViewModel>();
            viewViewModelRegister.Register<DatapointEditorPage, DatapointEditorViewModel>();
            viewViewModelRegister.Register<UserInstallationsPage, UserInstallationsViewModel>();
        }
    }
}