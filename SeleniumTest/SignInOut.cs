using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Threading;

namespace SeleniumTest
{
    [TestFixture]
    class SignInOut
    {
        private IWebDriver driver;
        private IWebElement logInButton;
        private IWebElement inputEmail;
        private IWebElement inputPassword;
        private IWebElement signInButton;
        private IWebElement textError;
        public IDictionary<string, object> vars { get; private set; }
        private IJavaScriptExecutor js;
        private int implicitWait = 80; 
        private const string _URL = "https://eventsexpress-test.azurewebsites.net/";
        private string logInButtonSelectorName = "MuiButtonBase-root";
        private string inputEmailName = "email";
        private string inputParrwordName = "password";
        private string email = "user@gmail.com";
        private string password = "1qaz1qaz";
        private string signInButtonSelector = "body > div.MuiDialog-root > div.MuiDialog-container.MuiDialog-scrollPaper > div > div > div.MuiTypography-root.MuiTypography-body1 > div > form > div:nth-child(3) > div > button:nth-child(2)";
        private string textErrorSelector = "body > div.MuiDialog-root > div.MuiDialog-container.MuiDialog-scrollPaper > div > div > div.MuiTypography-root.MuiTypography-body1 > div > div.text-danger.text-center";
        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver(@"C:\Users\Admin\Desktop");
            driver.Manage().Window.Maximize();
            

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
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(implicitWait);
            logInButton = driver.FindElement(By.ClassName(logInButtonSelectorName));
            
            logInButton.Click();
            inputEmail = driver.FindElement(By.Name(inputEmailName));
            inputEmail.SendKeys(email);
            inputPassword = driver.FindElement(By.Name(inputParrwordName));
            inputPassword.SendKeys(password);
            signInButton = driver.FindElement(By.CssSelector(signInButtonSelector));
            signInButton.Click();
            textError = driver.FindElement(By.CssSelector(textErrorSelector));
            Assert.AreEqual(textError.Text, "Incorrect login or password");
            Thread.Sleep(3000);
        }
    }
}
