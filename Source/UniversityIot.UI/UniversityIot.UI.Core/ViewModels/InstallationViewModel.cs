using UniversityIot.UI.Core.Models;
using UniversityIot.UI.Core.MVVM;
using UniversityIot.UI.Core.Services;

namespace UniversityIot.UI.Core.ViewModels
{
    using System.Windows.Input;
    using Xamarin.Forms;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    public class InstallationViewModel : BaseViewModel
    {
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

        public InstallationViewModel(InstallationModel installationModel)
        {
            this.InstallationName = installationModel.SerialNumber;
            this.Description = installationModel.Description;

            // TODO
            this.Datapoints = new ObservableCollection<DatapointModel>(new List<DatapointModel>
            {
                new DatapointModel
                {
                    Description = "description",
                    HexAddress = "0x9999",
                    Id = 1,
                    IsReadOnly = false,
                    Value = 15
                },
                new DatapointModel
                {
                    Description = "description",
                    HexAddress = "0x9999",
                    Id = 1,
                    IsReadOnly = false,
                    Value = 15
                }
            });
        }

        public ICommand Test => new Command(() =>
        {

        });
    }
}