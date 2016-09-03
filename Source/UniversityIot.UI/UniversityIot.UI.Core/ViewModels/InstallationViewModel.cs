using UniversityIot.UI.Core.DataAccess;
using UniversityIot.UI.Core.Models;
using UniversityIot.UI.Core.MVVM;
using UniversityIot.UI.Core.Services;

namespace UniversityIot.UI.Core.ViewModels
{
    using System.Windows.Input;
    using Xamarin.Forms;
    using System.Collections.ObjectModel;

    public class InstallationViewModel : BaseViewModel
    {
        private readonly IDatapointsRepository datapointsRepository;
        private string installationName;
        private string _description;

        public ObservableCollection<DatapointModel> Datapoints { get; set; }

        public string Description
        {
            get { return _description; }
            set
            {
                if (value == _description) return;
                _description = value;
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

        public InstallationViewModel(InstallationModel installationModel, IDatapointsRepository datapointsRepository)
        {
            this.datapointsRepository = datapointsRepository;
            this.InstallationName = installationModel.SerialNumber;
            this.Description = installationModel.Description;

            var datapoints = this.datapointsRepository.GetByInstallationId(installationModel.Id);
            this.Datapoints = new ObservableCollection<DatapointModel>(datapoints);
        }

        public ICommand Test => new Command(() =>
        {
        });
    }
}