using UniversityIot.DataAccess.Models;
using UniversityIot.DataAccess.Services;

namespace UniversityIot.UI.Core.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows.Input;
    using UniversityIot.UI.Mvvm;
    using Xamarin.Forms;

    public class UserInstallationsViewModel : BaseViewModel
    {
        private readonly IInstallationsRepository installationsRepository;
        private readonly INavigationService navigationService;
        public ObservableCollection<InstallationViewModel> Installations { get; set; }

        public ICommand ItemTappedCommand => new Command<InstallationViewModel>(
            async (installation) =>
            {
                InstallationModel installationModel =
                    await this.installationsRepository.GetInstallationById(installation.InstallationId);

                var installationDetailsViewModel = new InstallationDetailsViewModel(
                    installationModel, 
                    DraftContainer.DatapointsRepository);

                await installationDetailsViewModel.LoadDatapointsForInstallation(installationModel.Id);

                await this.navigationService.Push(installationDetailsViewModel, true);
            });

        public UserInstallationsViewModel(
            IEnumerable<InstallationModel> installationModels,
            IInstallationsRepository installationsRepository,
            INavigationService navigationService)
        {
            this.installationsRepository = installationsRepository;
            this.navigationService = navigationService;

            IEnumerable<InstallationViewModel> installationsViewModels =
                installationModels.Select(installation => new InstallationViewModel(DraftContainer.InstallationsRepository, this.navigationService)
                {
                    InstallationId = installation.Id,
                    Description = installation.Description,
                    SerialNumber = installation.SerialNumber
                });

            this.Installations = new ObservableCollection<InstallationViewModel>(installationsViewModels);
        }
    }
}