using University.Selenium.Framework.Browser;
using University.Selenium.Framework.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace University.Selenium.Framework.Pages
{
    public class ExamplePage
    {
        private string examplePageMainScreen = "btnK";
        private string exampleText = "Szukaj w Google";

        [FindsBy(How = How.Id, Using = "get-data")]
        private IWebElement showTableButton;

        private string textAreaWaitSelector = "//textarea";
        
        [FindsBy(How = How.Id, Using = "SearchInstallations")]
        private IWebElement filterInstallationInput;

        private string allVisibleInstallations = "//div[@id='installations']/div[starts-with(@style,'display: block;')]";

        public void goToExample()
        {
            Driver.goToExamplePage();
        }

        public bool checkIfGotToExample()
        {
            IWebElement exampleLink = Driver.webDriver.FindElement(By.Name(this.examplePageMainScreen));
            var inputValue = exampleLink.GetAttribute("value");
            return inputValue == exampleText;
        }

        public bool checkIfInstallationLoaded()
        {
            return showTableButton.Displayed;
        }

        public bool waitForPrivateDataToLoad()
        {
            return showTableButton.Displayed;
        }

        public bool filterInstallationName(string installationName)
        {
            filterInstallationInput.SendKeys(installationName);
            this.filterInstallationInput.SendKeys(Keys.Enter);
            Thread.Sleep(500);

            var allVisibleInstallations = Driver.webDriver.FindElements(By.XPath(this.allVisibleInstallations));

            if (allVisibleInstallations.Count == 1)
            {
                //check wether correnct installation in collection of one element
                return Driver.webDriver.FindElement(By.XPath(this.examplePageMainScreen)).Displayed;

            }
            else
            {
                return false;
            }
        }

        public ExamplePage goToLink1()
        {
            return Page.ExamplePage;
        }

        public ExamplePage goToLink2()
        {
            return Page.ExamplePage;
        }
    } 
}
