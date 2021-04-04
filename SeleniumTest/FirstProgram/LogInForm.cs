using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace SeleniumTest.FirstProgram
{
    public class LogInForm
    {
        [FindsBy(How=How.Name, Using = "UserName")]
        private IWebElement _userName;
        [FindsBy(How = How.Name, Using = "Password")]
        private IWebElement _password;
        [FindsBy(How = How.Name, Using = "Login")]
        private IWebElement _login;

        [Obsolete]
        public LogInForm()
        {
            PageFactory.InitElements(Driver.driver, this);
        }

        [Obsolete]
        public PageElements Login(string userName, string password)
        {
            _userName.SendKeys(userName);
            _password.SendKeys(password);
            _login.Submit();
            return new PageElements();
        }
    }
}
