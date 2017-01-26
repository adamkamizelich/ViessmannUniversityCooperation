using University.Selenium.Framework.Utilities;
using OpenQA.Selenium;

namespace University.Selenium.Framework.Browser
{
    public static class Driver
    {
        public static IWebDriver webDriver = DriverMethods.getDriverType();


        public static ISearchContext Browser
        {
            get { return webDriver; }
        }

        public static string getPageTitle
        {
            get
            {
                return webDriver.Title;
            }
        }
        public static void goToExamplePage()
        {
            webDriver.Url = Settings.baseUrl;
        }

        public static void exit()
        {
            webDriver.Close();
            webDriver.Quit();
            webDriver.Dispose();
        }     

        public static void implicitWait()
        {
            webDriver.Manage().Timeouts().ImplicitlyWait(Settings.implicitWaitTimeout);
        }
    }
}
