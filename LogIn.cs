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
    class LogIn
    {
        private IWebDriver driver;

        [FindsBy(How = How.ClassName, Using = "MuiButtonBase-root")]
        private IWebElement logInButton;

        [FindsBy(How = How.Name, Using = "email")]
        private IWebElement inputEmail;

        [FindsBy(How = How.Name, Using = "password")]
        private IWebElement inputPassword;

        [FindsBy(How = How.CssSelector, Using = "body > div.MuiDialog-root > div.MuiDialog-container.MuiDialog-scrollPaper > div > div > div.MuiTypography-root.MuiTypography-body1 > div > form > div:nth-child(3) > div > button:nth-child(2)")]
        private IWebElement signInButton;

        //[FindsBy(How = How.CssSelector, Using = "body > div.MuiDialog-root > div.MuiDialog-container.MuiDialog-scrollPaper > div > div > div.MuiTypography-root.MuiTypography-body1 > div > div.text-danger.text-center")]
        private IWebElement textError;

        public IDictionary<string, object> vars { get; private set; }
        private IJavaScriptExecutor js;
        private int implicitWait = 50;
        private const string _URL = "https://eventsexpress-test.azurewebsites.net/";
        private string email = "user@gmail.com";
        private string password = "1qaz1qaz";
        private string textErrorSelector = "body > div.MuiDialog-root > div.MuiDialog-container.MuiDialog-scrollPaper > div > div > div.MuiTypography-root.MuiTypography-body1 > div > div.text-danger.text-center";
        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver(@"C:\Users\Admin\Desktop");
            driver.Manage().Window.Maximize();
            PageFactory.InitElements(driver, this);
            js = (IJavaScriptExecutor)driver;
            vars = new Dictionary<string, object>();
        }
        [TearDown]
        protected void TearDown()
        {
            driver.Close();
        }


        [Test]


        public void SignInOutTest()
        {
            driver.Navigate().GoToUrl(_URL);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            logInButton.Click();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            inputEmail.SendKeys(email);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            inputPassword.SendKeys(password);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            signInButton.Click();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            textError = driver.FindElement(By.CssSelector(textErrorSelector));
            Assert.AreEqual(textError.Text, "Incorrect login or password");
        }
    }
}
