using System;
using System.Diagnostics;
using System.Windows.Input;
using UniversityIot.UI.Core.Models;
using UniversityIot.UI.Core.MVVM;
using Xamarin.Forms;

namespace UniversityIot.UI.Core.ViewModels
{
    public class InstallationViewModel : BaseViewModel
    {
        public long InstallationId { get; set; }
        public string SerialNumber { get; set; }
        public string Description { get; set; }

        public ICommand ShowInstallationDetails => new Command(async () =>
        {
            try
            {
                // TODO
                InstallationModel installationModel = 
                    await DraftContainer.InstallationsRepository.GetInstallationById(this.InstallationId);

                var installationDetailsViewModel = new InstallationDetailsViewModel(
                    installationModel, DraftContainer.DatapointsRepository);

                // TODO temporary
                await installationDetailsViewModel.LoadDatapointsForInstallation(installationModel.Id);

                await this.NavigationService.Push(installationDetailsViewModel);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error when showing installation details", ex);
            }
        });
    }
}