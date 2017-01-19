namespace UniversityIot.UI.Core.Views
{
    using Xamarin.Forms;

    public class InstalationsMasterDetailPage : MasterDetailPage
    {
        public InstalationsMasterDetailPage()
        {
            this.MasterBehavior = MasterBehavior.Popover;

            this.Master = new HamburgerMenuPage();
            this.Detail = new NavigationPage(new UserInstallationsPage());
        }
    }
}