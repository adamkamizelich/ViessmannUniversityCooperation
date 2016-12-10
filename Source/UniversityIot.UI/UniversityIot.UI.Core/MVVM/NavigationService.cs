using System.Threading.Tasks;
using Xamarin.Forms;

namespace UniversityIot.UI.Core.MVVM
{
    public class NavigationService : INavigationService
    {
        // TODO
        private INavigation navigation;
        private INavigation Navigation => this.navigation ?? (this.navigation = App.Current.MainPage.Navigation);
        private readonly ViewViewModelRegister viewViewModelRegister;

        public NavigationService(ViewViewModelRegister viewViewModelRegister)
        {
            this.viewViewModelRegister = viewViewModelRegister;
        }

        public async Task Push(BaseViewModel viewModel, bool hasNavigationBar = false)
        {
            Page view = this.viewViewModelRegister.GetViewFor(viewModel);
            NavigationPage.SetHasNavigationBar(view, hasNavigationBar);
            await this.Navigation.PushAsync(view);
        }

        // TODO remove ?
        public async Task<TViewModel> Pop<TViewModel>()
            where TViewModel : BaseViewModel
        {
            Page view = await this.Navigation.PopAsync();
            return view.BindingContext as TViewModel;
        }

        public async Task Pop()
        {
            await this.Navigation.PopAsync();
        }

        public async Task PopToRootAsync()
        {
            await this.Navigation.PopToRootAsync();
        }
    }
}