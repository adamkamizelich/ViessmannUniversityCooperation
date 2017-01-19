namespace UniversityIot.UI.Core.Views
{
    using System.Collections.Generic;
    using UniversityIot.UI.Core.DataAccess;
    using UniversityIot.UI.Core.Models;
    using UniversityIot.UI.Core.ViewModels;
    using Xamarin.Forms;

    public partial class UserInstallationsPage : ContentPage
    {
        public UserInstallationsPage()
        {
            this.InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            NavigationPage.SetHasNavigationBar(this, false);

            IInstallationsRepository installationsRepository = DraftContainer.InstallationsRepository;

            int userId = DraftContainer.AppSession.UserAuth.Id;

            List<InstallationModel> installationModels = await installationsRepository.GetAllByUserId(userId);

            this.BindingContext = new UserInstallationsViewModel(installationModels);

            base.OnAppearing();
        }
    }
}