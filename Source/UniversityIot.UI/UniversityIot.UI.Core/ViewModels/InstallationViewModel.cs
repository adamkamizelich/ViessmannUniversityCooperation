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
            // TODO
            InstallationModel installationModel = 
                await DraftContainer.InstallationsRepository.GetInstallationById(this.InstallationId);

            var installationDetailsViewModel = new InstallationDetailsViewModel(
                installationModel, DraftContainer.DatapointsRepository);

            await this.NavigationService.Push(installationDetailsViewModel);
        });
    }
}