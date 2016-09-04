using UniversityIot.UI.Core.Services;
using UniversityIot.UI.Core.ViewModels;
using UniversityIot.UI.Core.Views;
using Xamarin.Forms;

namespace UniversityIot.UI.Core
{
    public class App : Application
    {
        public App()
        {
            // The root page of your application

            var credentialsService = DependencyService.Get<ICredentialsService>();

            var loginViewModel = new LoginViewModel(
                DraftContainer.UserManagementService,
                credentialsService,
                DraftContainer.InstallationsRepository);

            Page loginView = DraftContainer.ViewViewModelRegister.GetViewFor(loginViewModel);

            MainPage = new NavigationPage(loginView);
        }

        public static string AppName => "Com.Viessmann.UniversityIot.UI";

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
