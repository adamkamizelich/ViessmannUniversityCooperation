using System.Threading.Tasks;
using Xamarin.Forms;

namespace UniversityIot.UI.Core.MVVM
{
    public class NavigationService : INavigationService
    {
        private readonly INavigation navigation;
        private readonly ViewViewModelRegister viewViewModelRegister;

        public NavigationService(INavigation navigation, ViewViewModelRegister viewViewModelRegister)
        {
            this.navigation = navigation;
            this.viewViewModelRegister = viewViewModelRegister;
        }

        public async Task Push(BaseViewModel viewModel)
        {
            Page view = this.viewViewModelRegister.GetViewFor(viewModel);
            await this.navigation.PushAsync(view);
        }

        public async Task<TViewModel> Pop<TViewModel>()
            where TViewModel : BaseViewModel
        {
            Page view = await this.navigation.PopAsync();
            return view.BindingContext as TViewModel;
        }
        public async Task PopToRootAsync()
        {
            await this.navigation.PopToRootAsync();
        }
    }
}