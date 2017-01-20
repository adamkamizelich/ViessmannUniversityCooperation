using UniversityIot.DataAccess.Models;
using UniversityIot.DataAccess.Services;

namespace UniversityIot.UI.Core.ViewModels
{
    using System;
    using System.Diagnostics;
    using System.Windows.Input;
    using UniversityIot.UI.Mvvm;
    using Xamarin.Forms;

    public class DatapointViewModel : BaseViewModel
    {
        private readonly IDatapointsRepository datapointsRepository;
        private readonly INavigationService navigationService;
        public long DatapointId { get; set; }
        public string Description { get; set; }
        public object DatapointValue { get; set; }

        public ICommand ShowDatapointEditorCommand => new Command(async () =>
        {
            try
            {
                DatapointModel datapointModel =
                    await this.datapointsRepository.GetByDatapointId(this.DatapointId);

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

        public DatapointViewModel(
            IDatapointsRepository datapointsRepository,
            INavigationService navigationService)
        {
            this.datapointsRepository = datapointsRepository;
            this.navigationService = navigationService;
        }
    }
}