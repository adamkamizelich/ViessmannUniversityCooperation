using UniversityIot.DataAccess.Models;
using UniversityIot.DataAccess.Services;

namespace UniversityIot.UI.Core.Views
{
    using System.Collections.Generic;
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

            int userId = DraftContainer.CredentialsProvider.UserAuth.Id;

            List<InstallationModel> installationModels = await installationsRepository.GetAllByUserId(userId);

            this.BindingContext = new UserInstallationsViewModel(
                installationModels,
                installationsRepository,
                DraftContainer.NavigationService);

            base.OnAppearing();
        }
    }
}