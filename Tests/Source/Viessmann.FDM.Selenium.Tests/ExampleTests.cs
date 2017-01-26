using Microsoft.VisualStudio.TestTools.UnitTesting;
using University.Selenium.Framework.Browser;
using University.Selenium.Framework.Utilities;
using OpenQA.Selenium.Support.Events;

namespace University.Selenium.Tests
{
    [TestClass]
    public class ExampleTests
    {
        [TestInitialize]
        public void Initialize()
        {
            var screensotDriver = new EventFiringWebDriver(DriverMethods.getDriverType());
            screensotDriver.ExceptionThrown += DriverMethods.TakeScreenshotOnException;
            Driver.webDriver = screensotDriver;

        }

        [TestMethod]
        public void ExampleShouldSuccess()
        {
            //arrange
            Driver.goToExamplePage();
            Driver.implicitWait();

            //act
            Page.ExamplePage.goToLink1().goToLink2();
            
            //assert
            Assert.IsTrue(Page.ExamplePage.checkIfGotToExample());         
        }

        [TestCleanup]
        public void Cleanup()
        {
            Driver.exit();
        }
    }
}
