namespace UniversityIot.UI.Core.ViewModels
{
    using System;
    using System.Diagnostics;
    using System.Windows.Input;
    using UniversityIot.UI.Core.DataAccess;
    using UniversityIot.UI.Core.Models;
    using UniversityIot.UI.Mvvm;
    using Xamarin.Forms;

    public class DatapointEditorViewModel : BaseViewModel
    {
        private readonly IDatapointsRepository datapointsRepository;
        private readonly INavigationService navigationService;
        public DatapointModel DatapointModel { get; set; }

        public ICommand SaveChangesCommand => new Command(async () =>
        {
            try
            {
                this.datapointsRepository.SaveChanges(this.DatapointModel);
                await this.navigationService.Pop();
            }
            catch (Exception ex)
            {
                // TODO saving error -> print message
                Debug.WriteLine($"Error while saving datapoint changes. {ex}");
            }
        });

        public DatapointEditorViewModel(
            DatapointModel datapointModel,
            IDatapointsRepository datapointsRepository,
            INavigationService navigationService)
        {
            this.DatapointModel = datapointModel;
            this.datapointsRepository = datapointsRepository;
            this.navigationService = navigationService;
        }
    }
}