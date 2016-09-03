using UniversityIot.UI.Core.MVVM;
using UniversityIot.UI.Core.Services;
using UniversityIot.UI.Core.ViewModels;
using Xamarin.Forms;

namespace UniversityIot.UI.Core.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();

            var credentialsService = DependencyService.Get<ICredentialsService>();

            BindingContext = new LoginViewModel(new UserManagementService(), credentialsService);
        }
    }
}