namespace UniversityIot.UI.Core.Views
{
    using Xamarin.Forms;

    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            this.InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);
        }
    }
}