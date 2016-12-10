using UniversityIot.UI.Core.ViewModels;
using Xamarin.Forms;

namespace UniversityIot.UI.Core.Views
{
    public partial class UserInstallationsPage : ContentPage
    {
        public UserInstallationsPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            NavigationPage.SetHasNavigationBar(this,false);

            var installationsRepository = DraftContainer.InstallationsRepository;

            var userId = DraftContainer.AppSession.UserAuth.Id;

            var installationModels = await installationsRepository.GetAllByUserId(userId);

            this.BindingContext = new UserInstallationsViewModel(installationModels);

            base.OnAppearing();
        }
    }
}
