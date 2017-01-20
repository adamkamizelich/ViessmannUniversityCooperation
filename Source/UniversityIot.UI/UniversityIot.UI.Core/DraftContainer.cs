using UniversityIot.DataAccess;
using UniversityIot.DataAccess.Authentication;
using UniversityIot.DataAccess.Services;

namespace UniversityIot.UI.Core
{
    using UniversityIot.UI.Core.Services;
    using UniversityIot.UI.Core.ViewModels;
    using UniversityIot.UI.Core.Views;
    using UniversityIot.UI.Mvvm;
    using Xamarin.Forms;

    public static class DraftContainer
    {
        public static NavigationService NavigationService { get; private set; }
        public static IDatapointsRepository DatapointsRepository { get; private set; }
        public static IUsersRepository UserManagementService { get; private set; }
        public static IInstallationsRepository InstallationsRepository { get; private set; }
        public static ViewViewModelRegister ViewViewModelRegister { get; }
        public static ICredentialsService CredentialsService { get; private set; }
        public static ICredentialsProvider CredentialsProvider { get; private set; }
        public static IAuthenticationService AuthenticationService { get; private set; }


        static DraftContainer()
        {
            CredentialsService = DependencyService.Get<ICredentialsService>();

            CredentialsProvider = new DataAccess.Authentication.CredentialsProvider();

            ViewViewModelRegister = new ViewViewModelRegister();
            NavigationService = new NavigationService(ViewViewModelRegister);
            AuthenticationService = new AuthenticationService(CredentialsProvider);
            DatapointsRepository = new DatapointsRestService(CredentialsProvider); // new FakeDatapointsRepository();
            UserManagementService = new UserRestService(CredentialsProvider);
            InstallationsRepository = new InstallationsRestService(CredentialsProvider); //new FakeInstallationRepository();

            RegisterViewModels(ViewViewModelRegister);
        }

        private static void RegisterViewModels(ViewViewModelRegister viewViewModelRegister)
        {
            viewViewModelRegister.Register<InstallationDetailsPage, InstallationDetailsViewModel>();
            viewViewModelRegister.Register<InstalationsMasterDetailPage, InstalationsMasterDetailViewModel>();
            viewViewModelRegister.Register<LoginPage, LoginViewModel>();
            viewViewModelRegister.Register<DatapointEditorPage, DatapointEditorViewModel>();
            viewViewModelRegister.Register<UserInstallationsPage, UserInstallationsViewModel>();
        }
    }

    public class CredentialsProvider
    {
        public IUserAuth Credentials { get; set; }
    }
}