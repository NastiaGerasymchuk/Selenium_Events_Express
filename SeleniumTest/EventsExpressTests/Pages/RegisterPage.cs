using OpenQA.Selenium;
using SeleniumTest.EventsExpressTests;
using SeleniumTest.EventsExpressTests.Pages;
using System;

namespace SeleniumTest
{
    public class RegisterPage:BaseClass
    {
        private By emailInput;
        private By passwordInput;
        private By loginBtn;
        private By textError;
        private By invalidEmail;
        private By requiredPassword;
        private string emailName = "email";
        private string passwordName = "password";
        private string cssLoginBtn = "body > div.MuiDialog-root > div.MuiDialog-container.MuiDialog-scrollPaper > div > div > div.MuiTypography-root.MuiTypography-body1 > div > form > div:nth-child(3) > div > button:nth-child(2)";
        private string cssTextError = "body > div.MuiDialog-root > div.MuiDialog-container.MuiDialog-scrollPaper > div > div > div.MuiTypography-root.MuiTypography-body1 > div > div.text-danger.text-center";        
        private string cssInvalidEmail = "body > div.MuiDialog-root > div.MuiDialog-container.MuiDialog-scrollPaper > div > div > div.MuiTypography-root.MuiTypography-body1 > div > form > div:nth-child(1) > div > p";
        private string cssRequiredPassword = "body > div.MuiDialog-root > div.MuiDialog-container.MuiDialog-scrollPaper > div > div > div.MuiTypography-root.MuiTypography-body1 > div > form > div:nth-child(2) > div > p";
        
        [Obsolete]
        public RegisterPage(IWebDriver driver):base(driver)
        {
            emailInput = Name(emailName);
            passwordInput = Name(passwordName);
            loginBtn = Css(cssLoginBtn);
            textError = Css(cssTextError);
            invalidEmail = Css(cssInvalidEmail);
            requiredPassword = Css(cssRequiredPassword);

    }
        public void SetEmail(string email)
        {
            SetInputField(emailInput, email);
        }
        public void SetPassword(string password)
        {
            SetInputField(passwordInput,password);
        }

        [Obsolete]
        public UserAdminPage LoginBtnClickValidData()
        {
            Click(loginBtn);
            return new UserAdminPage(driver);
        }

        public void Login(string email, string password)
        {
            SetInputField(emailInput, email);
            SetInputField(passwordInput, password);
            Click(loginBtn);
        }

        public RegisterPage InValidLogin(string email, string passsword)
        {
            Login(email,passsword);
            return this;

        }

        [Obsolete]
        public HomeEvent ValidLogin(string email, string passsword)
        {
            Login(email,passsword);
            return new HomeEvent(driver);

        }

        
        [Obsolete]
        public string GetErrorMessage(By by)
        {
            return Text(by);
        }

        [Obsolete]
        public string GetErrorEmail()
        {
           return GetErrorMessage(invalidEmail);
        }
        [Obsolete]
        public string GetErrorPassword()
        {
            return GetErrorMessage(requiredPassword);
        }
        [Obsolete]
        public string GetErrorData()
        {
            return GetErrorMessage(textError);
        }
    }
}
