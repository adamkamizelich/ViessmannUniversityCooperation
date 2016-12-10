using Xamarin.Forms;

namespace UniversityIot.UI.Core.Views
{
    public class InstalationsMasterDetailPage : MasterDetailPage
    {
        public InstalationsMasterDetailPage()
        {
            this.MasterBehavior = MasterBehavior.Popover;

            Master = new HamburgerMenuPage();
            Detail = new NavigationPage(new UserInstallationsPage());

        }
    }
}