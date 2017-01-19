namespace UniversityIot.UI.Core.ViewModels
{
    using System;
    using System.Diagnostics;
    using System.Windows.Input;
    using UniversityIot.UI.Core.Models;
    using UniversityIot.UI.Mvvm;
    using Xamarin.Forms;

    public class DatapointViewModel : BaseViewModel
    {
        private readonly INavigationService navigationService;
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

                var datapointEditorViewModel = new DatapointEditorViewModel(
                    datapointModel,
                    DraftContainer.DatapointsRepository,
                    DraftContainer.NavigationService);

                await this.navigationService.Push(datapointEditorViewModel);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error opening datapoint editor. {ex}");
            }
        });

        public DatapointViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
        }
    }
}