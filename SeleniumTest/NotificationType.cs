using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Threading;

namespace SeleniumTest
{
    [TestFixture]
    class NotificationType
    {
        private IWebDriver driver;

        [FindsBy(How = How.CssSelector, Using = "#panel5bh-header > div.MuiButtonBase-root.MuiIconButton-root.MuiExpansionPanelSummary-expandIcon.MuiIconButton-edgeEnd")]
        private IWebElement manageNotificationBtn;
        private IWebElement label;

        [FindsBy(How = How.CssSelector, Using = "#panel5bh-content > div > p > div > form > div:nth-child(1) > div:nth-child(1) > label > input[type=checkbox]")]
        private IWebElement firstInput;

        [FindsBy(How = How.CssSelector, Using = "#panel5bh-content > div > p > div > form > div:nth-child(1) > div:nth-child(2) > label > input[type=checkbox]")]
        private IWebElement secondInput;

        [FindsBy(How = How.CssSelector, Using = "#panel5bh-content > div > p > div > form > div:nth-child(1) > div:nth-child(3) > label > input[type=checkbox]")]
        private IWebElement thirdInput;

        private Dictionary<string, string> lblNameCount = new Dictionary<string, string>();     
        public IDictionary<string, object> vars { get; private set; }
        private IJavaScriptExecutor js;
        private int implicitWait = 80;
        private const string _URL = "https://localhost:44344/profile";
       
       
        [SetUp]
        [Obsolete]
        public void SetUp()
        {
            driver = new ChromeDriver(@"C:\Users\Admin\Desktop");
            driver.Manage().Window.Maximize();
            PageFactory.InitElements(driver, this);

            js = (IJavaScriptExecutor)driver;
            vars = new Dictionary<string, object>();
            lblNameCount.Add("1", "Own Event Change");
            lblNameCount.Add("2", "Profile Change");
            lblNameCount.Add("3", "Visited Event Change");
            
        }
        [TearDown]
        protected void TearDown()
        {
            driver.Close();
        }


        [Test]
        public void ChooseNotification()
        {
            driver.Navigate().GoToUrl(_URL);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(implicitWait);
            manageNotificationBtn.Click();
            Thread.Sleep(3000);
            foreach(var item in lblNameCount.Keys)
            {
                label = driver.FindElement(By.CssSelector("#panel5bh-content > div > p > div > form > div:nth-child(1) > div:nth-child("+item+") > label"));
                Assert.That(label.Text, Is.EqualTo(lblNameCount[item]));
            }
            label = driver.FindElement(By.CssSelector("#panel5bh-content > div > p > div > form > div:nth-child(1) > div:nth-child(1) > label"));
            label.Click();
            Assert.That(firstInput.GetAttribute("checked"), Is.EqualTo("true"));
            Assert.That(secondInput.GetAttribute("checked"), Is.Null);
            Assert.That(thirdInput.GetAttribute("checked"), Is.Null);          
        }
    }
}
