using System.Windows.Input;
using UniversityIot.UI.Core.Models;
using UniversityIot.UI.Core.MVVM;
using Xamarin.Forms;

namespace UniversityIot.UI.Core.ViewModels
{
    public class DatapointViewModel : BaseViewModel
    {
        public long DatapointId { get; set; }
        public string Description { get; set; }
        public string HexAddress { get; set; }

        public ICommand ShowDatapointEditorCommand => new Command(() =>
        {
            // TODO
            DatapointModel datapointModel = DraftContainer.DatapointsRepository.GetByDatapointId(this.DatapointId);

            var datapointEditorViewModel = new DatapointEditorViewModel(datapointModel, DraftContainer.DatapointsRepository);
            this.NavigationService.Push(datapointEditorViewModel);
        });
    }
}