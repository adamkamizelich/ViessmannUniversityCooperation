using System;
using System.Diagnostics;
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
        public object DatapointValue { get; set; }

        public ICommand ShowDatapointEditorCommand => new Command(async () =>
        {
            try
            {
                // TODO
                DatapointModel datapointModel = 
                    await DraftContainer.DatapointsRepository.GetByDatapointId(this.DatapointId);

                var datapointEditorViewModel = new DatapointEditorViewModel(datapointModel, DraftContainer.DatapointsRepository);
                await this.NavigationService.Push(datapointEditorViewModel);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error opening datapoint editor", ex);
            }
        });
    }
}