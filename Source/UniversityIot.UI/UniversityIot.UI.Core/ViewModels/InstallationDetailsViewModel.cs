using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversityIot.UI.Core.DataAccess;
using UniversityIot.UI.Core.Models;
using UniversityIot.UI.Core.MVVM;
using UniversityIot.UI.Core.Services;

namespace UniversityIot.UI.Core.ViewModels
{
    using System.Collections.ObjectModel;

    public class InstallationDetailsViewModel : BaseViewModel
    {
        private readonly IDatapointsRepository datapointsRepository;
        private string installationName;
        private string installationDescription;

        public ObservableCollection<DatapointViewModel> Datapoints { get; set; }

        public string InstallationDescription
        {
            get { return installationDescription; }
            set
            {
                if (value == installationDescription) return;
                installationDescription = value;
                OnPropertyChanged();
            }
        }

        public string InstallationName
        {
            get { return installationName; }
            set
            {
                if (value == installationName) return;
                installationName = value;
                OnPropertyChanged();
            }
        }

        public InstallationDetailsViewModel(InstallationModel installationModel, IDatapointsRepository datapointsRepository)
        {
            this.datapointsRepository = datapointsRepository;
            this.InstallationName = installationModel.SerialNumber;
            this.InstallationDescription = installationModel.Description;
        }

        public async Task LoadDatapointsForInstallation(long installationModelId)
        {
            // Get model from data provider
            List<DatapointModel> datapoints = await this.datapointsRepository.GetByInstallationId(installationModelId);

            // Map models to ViewModels
            var datapointViewModels = datapoints.Select(dp => new DatapointViewModel
            {
                DatapointId = dp.Id,
                Description = dp.Description,
                DatapointValue = dp.DatapointValue
            });

            // Populate ListView source
            this.Datapoints = new ObservableCollection<DatapointViewModel>(datapointViewModels);
        }
    }
}