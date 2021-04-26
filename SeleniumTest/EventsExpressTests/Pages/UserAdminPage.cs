using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumTest.EventsExpressTests.Data;
using SeleniumTest.EventsExpressTests.Pages;
using System;
using System.Threading;

namespace SeleniumTest.EventsExpressTests
{
    public class UserAdminPage:BaseClass
    {
        private string cssHeaderProfile="#root > div.left-sidebar-closed.left-sidebar > div";
        //private object sidebar
        private string cssAddEventBtn = "#root > div.left-sidebar-closed.left-sidebar > div > div > div > div:nth-child(3) > div > button";
        private string cssHomeBtn = ".sidebar-header:nth-child(1) .nav-item-text";
        private string cssLastBtn = "#main > div.events-container > ul > div > div > button:last-child";
        private string cssFirstBtn = "#main > div.events-container > ul > div > div > button:nth-child(1)";
        private string cssDivResulEvents = "#main > div.events-container > div> div.col-12";
        private By headerProfile;
        private By addEventBtn;
        private By homeBtn;
        private SideBar sideBar;
        private By btnLast;
        private By btnFirst;
        private By divResultEvents;

        [Obsolete]
        public UserAdminPage(IWebDriver driver):base(driver)
        {
            headerProfile = Css(cssHeaderProfile);
            addEventBtn = Css(cssAddEventBtn);
            homeBtn = Css(cssHomeBtn);
            sideBar = new SideBar(driver);
            btnLast = Css(cssLastBtn);
            btnFirst = Css(cssFirstBtn);
            divResultEvents = Css(cssDivResulEvents);
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
        [Obsolete]
        public UserAdminPage ClickLastBtn()
        {
            Click(btnLast);
            return this;
        }
        [Obsolete]
        public UserAdminPage ClickFirstBtn()
        {
            Click(btnFirst);
            return this;
        }

        [Obsolete]
        public int GetEventcountOnLastPage()
        {
            //this.HomeBtnClick();
            try
            {
                wait.Until(ExpectedConditions.ElementIsVisible(btnFirst));
                IWebElement webElement = driver.FindElement(btnFirst);
                this.ClickFirstBtn();
                this.ClickLastBtn();
                return this.GetEventsCount();
            }
            catch (NoSuchElementException)
            {
                return this.GetEventsCount();
            }

        }
        [Obsolete]
        public int GetEventsCount()
        {
            return GetElementsCount(divResultEvents);
        }
        public AddEvent AddEventClick()
        {
            Click(addEventBtn);
            return new AddEvent(driver);
        }

        [Obsolete]
        public UserAdminPage HomeBtnClick()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(homeBtn)).Click();
           
            //Thread.Sleep(BaseConfigData.ThreadSleep);
            return new UserAdminPage(driver);
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
        public int GetCountElementSideBar()
        {
            return sideBar.GetNavElCount();
        }
    }
}

