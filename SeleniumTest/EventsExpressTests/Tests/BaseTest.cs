using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumTest.EventsExpressTests.Data;
using SeleniumTest.EventsExpressTests.Helpers;
using System;

namespace SeleniumTest.EventsExpressTests.Tests
{
    public class BaseTest
    {
        protected  IWebDriver driver;
        protected BaseConfigData BaseData;
        protected WebDriverWait wait;
        [SetUp]
        public virtual void SetUp()
        {
            driver = BrowserConfig.GetDriver();
            //driver = new ChromeDriver(BaseConfigData.ChromeDriver);
            //driver.Manage().Window.Maximize();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(BaseConfigData.SecondsWaintings));
        }

       
        private void GetScreen(string name)
        {
            string path = BaseConfigData.FallTestFolder;
            string fullPath = path + name;
            var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            screenshot.SaveAsFile(fullPath, ScreenshotImageFormat.Png);

        }
        protected HomeEvent GetHomeObject()
        {
            driver.Navigate().GoToUrl(BaseConfigData.Uri);
            return new HomeEvent(driver);
        }

        [TearDown]
        public virtual void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                string testName = TestContext.CurrentContext.Test.Name;
                GetScreen(testName);
            }
            //driver.Close();
            driver.CloseDriver();
        }


    }
}
