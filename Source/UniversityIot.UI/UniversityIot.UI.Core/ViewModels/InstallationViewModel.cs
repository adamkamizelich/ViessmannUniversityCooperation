using UniversityIot.DataAccess.Models;
using UniversityIot.DataAccess.Services;

namespace UniversityIot.UI.Core.ViewModels
{
    using System;
    using System.Diagnostics;
    using System.Windows.Input;
    using UniversityIot.UI.Mvvm;
    using Xamarin.Forms;

    public class InstallationViewModel : BaseViewModel
    {
        private readonly IInstallationsRepository installtionsRepository;
        private readonly INavigationService navigationService;
        public long InstallationId { get; set; }
        public string SerialNumber { get; set; }
        public string Description { get; set; }

        public ICommand ShowInstallationDetails => new Command(async () =>
        {
            try
            {
                InstallationModel installationModel =
                    await this.installtionsRepository.GetInstallationById(this.InstallationId);

                var installationDetailsViewModel = new InstallationDetailsViewModel(
                    installationModel, DraftContainer.DatapointsRepository);

                await installationDetailsViewModel.LoadDatapointsForInstallation(installationModel.Id);

                await this.navigationService.Push(installationDetailsViewModel);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error when showing installation details. {ex}");
            }
        });

        public InstallationViewModel(
            IInstallationsRepository installtionsRepository,
            INavigationService navigationService)
        {
            this.installtionsRepository = installtionsRepository;
            this.navigationService = navigationService;
        }
    }
}