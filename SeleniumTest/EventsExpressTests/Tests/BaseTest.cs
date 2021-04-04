using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumTest.EventsExpressTests.Data;
using System;

namespace SeleniumTest.EventsExpressTests.Tests
{
    public class BaseTest
    {
        protected  IWebDriver driver;
        protected BaseData BaseData;
        protected WebDriverWait wait;
        [SetUp]
        public virtual void SetUp()
        {
            driver = new ChromeDriver(BaseData.ChromeDriver);
            driver.Manage().Window.Maximize();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(BaseData.SecondsWaintings));
        }

       
        private void GetScreen(string name)
        {
            string path = BaseData.FallTestFolder;
            string fullPath = path + name;
            var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            screenshot.SaveAsFile(fullPath, ScreenshotImageFormat.Png);

        }
        protected HomeEvent GetHomeObject()
        {
            driver.Navigate().GoToUrl(BaseData.Uri);
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
        }


    }
}
