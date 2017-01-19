namespace UniversityIot.UI.Core.ViewModels
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Threading.Tasks;
    using UniversityIot.UI.Core.DataAccess;
    using UniversityIot.UI.Core.Models;
    using UniversityIot.UI.Mvvm;

    public class InstallationDetailsViewModel : BaseViewModel
    {
        private readonly IDatapointsRepository datapointsRepository;
        private string installationDescription;
        private string installationName;
        public ObservableCollection<DatapointViewModel> Datapoints { get; set; }

        public string InstallationDescription
        {
            get
            {
                return this.installationDescription;
            }
            set
            {
                if (value == this.installationDescription)
                {
                    return;
                }

                this.installationDescription = value;
                this.OnPropertyChanged();
            }
        }

        public string InstallationName
        {
            get
            {
                return this.installationName;
            }
            set
            {
                if (value == this.installationName)
                {
                    return;
                }

                this.installationName = value;
                this.OnPropertyChanged();
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
            IEnumerable<DatapointViewModel> datapointViewModels = datapoints.Select(
                dp => new DatapointViewModel(DraftContainer.NavigationService)
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