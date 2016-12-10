using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using UniversityIot.UI.Core.DataAccess;
using UniversityIot.UI.Core.Models;
using UniversityIot.UI.Core.MVVM;
using Xamarin.Forms;

namespace UniversityIot.UI.Core.ViewModels
{
    public class UserInstallationsViewModel : BaseViewModel
    {
        public ObservableCollection<InstallationViewModel> Installations { get; set; }

        public UserInstallationsViewModel(IEnumerable<InstallationModel> installationModels)
        {
            var installationsViewModels = installationModels.Select(installation => new InstallationViewModel
            {
                InstallationId = installation.Id,
                Description = installation.Description,
                SerialNumber = installation.SerialNumber
            });

            this.Installations = new ObservableCollection<InstallationViewModel>(installationsViewModels);

            ItemTappedCommand = new Command(async (model) =>
            {
                InstallationViewModel installationViewModel = model as InstallationViewModel;

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

                await this.NavigationService.Push(installationDetailsViewModel, true);
                
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
        }

        public ICommand ItemTappedCommand { get; private set; }
    }
}