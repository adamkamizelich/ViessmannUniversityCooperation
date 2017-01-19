namespace UniversityIot.UI.Core.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows.Input;
    using UniversityIot.UI.Core.Models;
    using UniversityIot.UI.Mvvm;
    using Xamarin.Forms;

    public class UserInstallationsViewModel : BaseViewModel
    {
        private readonly INavigationService navigationService;
        public ObservableCollection<InstallationViewModel> Installations { get; set; }

        public ICommand ItemTappedCommand => new Command(async (model) =>
        {
            var installationViewModel = model as InstallationViewModel;

            if (installationViewModel == null)
            {
                throw new NotSupportedException();
            }

            // TODO
            InstallationModel installationModel =
                await DraftContainer.InstallationsRepository.GetInstallationById(installationViewModel.InstallationId);

            var installationDetailsViewModel = new InstallationDetailsViewModel(
                installationModel, DraftContainer.DatapointsRepository);

            // TODO temporary
            await installationDetailsViewModel.LoadDatapointsForInstallation(installationModel.Id);

            await this.navigationService.Push(installationDetailsViewModel, true);

            /*    s
                  var installation = new InstallationModel()
                  {
                      Id = installationViewModel.InstallationId,
                      Description = installationViewModel.Description,
                      SerialNumber = installationViewModel.SerialNumber
                  };
  
                  await this.NavigationService.Push(new InstallationDetailsViewModel(installation, DraftContainer.DatapointsRepository));
              */
        });

        public UserInstallationsViewModel(
            IEnumerable<InstallationModel> installationModels,
            INavigationService navigationService)
        {
            this.navigationService = navigationService;

            IEnumerable<InstallationViewModel> installationsViewModels =
                installationModels.Select(installation => new InstallationViewModel(DraftContainer.NavigationService)
                {
                    InstallationId = installation.Id,
                    Description = installation.Description,
                    SerialNumber = installation.SerialNumber
                });

            this.Installations = new ObservableCollection<InstallationViewModel>(installationsViewModels);
        }
    }
}