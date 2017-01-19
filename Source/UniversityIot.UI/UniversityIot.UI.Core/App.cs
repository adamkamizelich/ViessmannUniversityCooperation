namespace UniversityIot.UI.Core
{
    using UniversityIot.UI.Core.ViewModels;
    using Xamarin.Forms;

    public class App : Application
    {
        public static string AppName => "Com.Viessmann.UniversityIot.UI";

        public App()
        {
            // The root page of your application

            var loginViewModel = new LoginViewModel(
                DraftContainer.AppSession,
                DraftContainer.UserManagementService,
                DraftContainer.CredentialsService,
                DraftContainer.NavigationService);

            Page loginView = DraftContainer.ViewViewModelRegister.GetViewFor(loginViewModel);

            this.MainPage = new NavigationPage(loginView);
        }

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