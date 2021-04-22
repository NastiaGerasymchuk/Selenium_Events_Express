using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumTest.EventsExpressTests.Pages;
using System;

namespace SeleniumTest.EventsExpressTests
{
    public class UserAdminPage:BaseClass
    {
        private string cssHeaderProfile="#root > div.left-sidebar-closed.left-sidebar > div";
        private string cssAddEventBtn = "#root > div.left-sidebar-closed.left-sidebar > div > div > div > div:nth-child(3) > div > button";
        private string cssHomeBtn = "#root > div.left-sidebar-closed.left-sidebar > nav > ul > li:nth-child(1) > a";
        private By headerProfile;
        private By addEventBtn;
        private By homeBtn;



        [Obsolete]
        public UserAdminPage(IWebDriver driver):base(driver)
        {
            headerProfile = Css(cssHeaderProfile);
            addEventBtn = Css(cssAddEventBtn);
            homeBtn = Css(cssHomeBtn);
        }
        public bool ExistUser_Admin()
        {
            try
            {
               return wait.Until(ExpectedConditions.ElementIsVisible(headerProfile)).Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        public AddEvent AddEventClick()
        {
            Click(addEventBtn);
            return new AddEvent(driver);
        }
        public UserAdminPage HomeBtnClick()
        {
            Click(homeBtn);
            return this;
        }
        public bool IsVisibleAddEvent()
        {
            try
            {
                IWebElement webElement = driver.FindElement(addEventBtn);

                return webElement.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}

