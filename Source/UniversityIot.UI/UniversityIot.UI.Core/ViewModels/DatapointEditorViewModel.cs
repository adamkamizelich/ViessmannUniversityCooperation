using System.Windows.Input;
using UniversityIot.UI.Core.DataAccess;
using UniversityIot.UI.Core.Models;
using UniversityIot.UI.Core.MVVM;
using Xamarin.Forms;

namespace UniversityIot.UI.Core.ViewModels
{
    public class DatapointEditorViewModel : BaseViewModel
    {
        public DatapointModel DatapointModel { get; set; }

        private readonly IDatapointsRepository datapointsRepository;

        public DatapointEditorViewModel(DatapointModel datapointModel, IDatapointsRepository datapointsRepository)
        {
            this.DatapointModel = datapointModel;
            this.datapointsRepository = datapointsRepository;
        }

        public ICommand SaveChangesCommand => new Command(async () =>
        {
            // TODO saving error -> message
            this.datapointsRepository.SaveChanges(this.DatapointModel);
            await this.NavigationService.Pop();
        });
    }
}