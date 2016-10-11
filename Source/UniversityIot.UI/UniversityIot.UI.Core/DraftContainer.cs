using UniversityIot.UI.Core.DataAccess;
using UniversityIot.UI.Core.MVVM;
using UniversityIot.UI.Core.Services;
using UniversityIot.UI.Core.ViewModels;
using UniversityIot.UI.Core.Views;
using Xamarin.Forms;

namespace UniversityIot.UI.Core
{
    public static class DraftContainer
    {
        static DraftContainer()
        {
            CredentialsService = DependencyService.Get<ICredentialsService>();

            AppSession = new AppSession();

            ViewViewModelRegister = new ViewViewModelRegister();
            NavigationService = new NavigationService(ViewViewModelRegister);
            DatapointsRepository = new DatapointsRestService(AppSession);
            UserManagementService = new UserRestService(AppSession);
            InstallationsRepository = new InstallationsRestService(AppSession);

            RegisterViewModels(ViewViewModelRegister);
        }

        public static NavigationService NavigationService { get; private set; }
        public static IDatapointsRepository DatapointsRepository { get; private set; }
        public static IUsersRepository UserManagementService { get; private set; }
        public static IInstallationsRepository InstallationsRepository { get; private set; }
        public static ViewViewModelRegister ViewViewModelRegister { get; }
        public static ICredentialsService CredentialsService { get; private set; }
        public static IAppSession AppSession { get; set; }

        private static void RegisterViewModels(ViewViewModelRegister viewViewModelRegister)
        {
            viewViewModelRegister.Register<InstallationDetailsPage, InstallationDetailsViewModel>();
            viewViewModelRegister.Register<LoginPage, LoginViewModel>();
            viewViewModelRegister.Register<DatapointEditorPage, DatapointEditorViewModel>();
            viewViewModelRegister.Register<UserInstallationsPage, UserInstallationsViewModel>();
        }
    }
}