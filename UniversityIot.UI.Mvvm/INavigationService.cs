namespace UniversityIot.UI.Mvvm
{
    using System.Threading.Tasks;

    public interface INavigationService
    {
        Task Push(BaseViewModel viewModel, bool hasNavigationBar = false);

        Task<TViewModel> Pop<TViewModel>()
            where TViewModel : BaseViewModel;

        Task PopToRootAsync();

        Task Pop();
    }
}