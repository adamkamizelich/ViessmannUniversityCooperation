using System.Threading.Tasks;

namespace UniversityIot.UI.Core.MVVM
{
    public interface INavigationService
    {
        Task Push(BaseViewModel viewModel);
        Task<TViewModel> Pop<TViewModel>()
            where TViewModel : BaseViewModel;
        Task PopToRootAsync();
        Task Pop();
    }
}