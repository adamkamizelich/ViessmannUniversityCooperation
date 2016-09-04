using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using UniversityIot.UI.Core.Models;
using UniversityIot.UI.Core.MVVM;

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
        }
    }
}