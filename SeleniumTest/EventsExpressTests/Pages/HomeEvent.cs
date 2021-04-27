using OpenQA.Selenium;
using SeleniumTest.EventsExpressTests;
using SeleniumTest.EventsExpressTests.Data;
using SeleniumTest.EventsExpressTests.Models;
using SeleniumTest.EventsExpressTests.Pages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SeleniumTest
{
    public class HomeEvent:BaseClass
    {

        private By rightSideBar;
        private By btnSearch;
        private By btnReset;
        private By btnSignIn;
        private By btnMore;
        private By btnLess;
        private By divFromBy;
        private By divdateFrom;
        private By divTo;
        private By divDateTo;
        private By divDateFromBy;
        private By btnLocation;
        private By listBoxHashTag;
        private By inputKeyword;
        private By btnHome;
        private By divResult;
        private By divResultEvents;
        private By divSelect;
        private By selectSetting;
        private By btnLast;
        private By btnFirst;
        private SideBar sideBar;
        private string cssRightSideBar = "#main > div.sidebar-filter";
        private string cssBtnSearch = "#main > div.sidebar-filter > form > div.d-flex > button:nth-child(2)";
        private string cssBtnReset = "#main > div.sidebar-filter > form > div.d-flex > button:nth-child(1)";
        private string nameSignIn = "MuiButtonBase-root";
        private string cssBtnMore = "#main > div.sidebar-filter > form > div:nth-child(2) > button";
        private string cssBtnLess = "#main > div.sidebar-filter > form > div:nth-child(7) > button";
        private string cssDivFromBy = "#main > div.sidebar-filter > form > div:nth-child(2) > div:nth-child(1)";
        private string cssDivDateFrom = "#main > div.sidebar-filter > form > div:nth-child(2) > div.react-datepicker-wrapper > div > input";
        private string cssDivTo = "#main > div.sidebar-filter > form > div:nth-child(3) > div:nth-child(1)";
        private string cssDivDateTo = "#main > div.sidebar-filter > form > div:nth-child(3) > div.react-datepicker-wrapper > div > input[type=text]";
        private string cssDivDateFromBy = "#main > div.sidebar-filter > form > div:nth-child(2) > div.react-datepicker-wrapper > div > input[type=text]";
        private string cssBtnLocation = "#main > div.sidebar-filter > form > div:nth-child(5) > div > button";
        private string cssListBox = "#main > div.sidebar-filter > form > div:nth-child(4) > div > div.rw-widget-input.rw-widget-picker.rw-widget-container > div > input";
        private string nameInputKeyword = "keyWord";
        private string cssBtnHome = "# root > div.left-sidebar-closed.left-sidebar > nav > ul > li > a";
        private string classDivResult = "h1";
        private string cssDivResulEvents = "#main > div.events-container > div> div.col-12";
        private string xPathDiveSelect = "/html/body/div[1]/div[3]/div[1]/form/div[4]/div/div[1]/div/ul/li/span";
        private string cssSelectSetting = "#rw_1_taglist > li > span";
        private string cssLastBtn = "#main > div.events-container > ul > div > div > button:last-child";
        private string cssFirstBtn = "#main > div.events-container > ul > div > div > button:nth-child(1)";
        
        public HomeEvent(IWebDriver driver):base(driver)
        {
            rightSideBar = Css(cssRightSideBar);
            btnSearch = Css(cssBtnSearch);
            btnReset = Css(cssBtnReset);
            btnSignIn = ClassName(nameSignIn);
            btnMore = Css(cssBtnMore);
            btnLess = Css(cssBtnLess);
            divFromBy = Css(cssDivFromBy);
            divdateFrom = Css(cssDivDateFrom);
            divTo = Css(cssDivTo);
            divDateTo = Css(cssDivDateTo);
            divDateFromBy = Css(cssDivDateFromBy);
            btnLocation = Css(cssBtnLocation);
            listBoxHashTag = Css(cssListBox);
            inputKeyword = Name(nameInputKeyword);
            btnHome = Css(cssBtnHome);
            divResult = ClassName(classDivResult);
            divResultEvents = Css(cssDivResulEvents);
            divSelect = Xpath(xPathDiveSelect);
            selectSetting = Css(cssSelectSetting);
            btnLast = Css(cssLastBtn);
            btnFirst = Css(cssFirstBtn);
            sideBar =new SideBar(driver);

        }

        [Obsolete]
        public UserAdminPage Login(User user)
        {             
            RegisterPage registerPage = Registration();
            registerPage.SetEmail(user.Email);
            registerPage.SetPassword(user.Password);
            return registerPage.LoginBtnClickValidData();
            
        }
        [Obsolete]
        public HomeEvent ClickRightSideBar()
        {
            Click(rightSideBar);
            return this;
        }
        [Obsolete]
        public HomeEvent ClickLastBtn()
        {
            Click(btnLast);
            return this;
        }
        [Obsolete]
        public HomeEvent ClickFirstBtn()
        {
            Click(btnFirst);
            return this;
        }

        [Obsolete]
        public int GetEventcountOnLastPage()
        {
            //HomeEvent res = new HomeEvent(driver);
            //res.ClickHomeBtn();
            //res.MoveDown();
            try
            {

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
        [Obsolete]
        public RegisterPage Registration()
        {
            Click(btnSignIn);
            return new RegisterPage(driver);
        }

        [Obsolete]
        public HomeEvent ClickHomeBtn()
        {
            Click(btnHome);
            return this;
        }

        [Obsolete]
        public string SearchResult()
        {
           return Text(divResult);
        }
        public HomeEvent SetInputKeyword(string words)
        {
            SetInputField(inputKeyword, words);
            return this;
        }

        [Obsolete]
        public string GetInputKeyWord()
        {
            return GetFieldValue(inputKeyword);
        }
       
        public HomeEvent ResetClick()
        {
            Click(btnReset);
            return this;
        }

        [Obsolete]
        public HomeEvent SearchClick()
        {       
            Click(btnSearch);
            return this;
        }

        [Obsolete]
        public bool GetEnabledBtnSearchState()
        {
            return EnabledElement(btnSearch);
        }
       

        [Obsolete]
        public HomeEvent BtnMoreClick()
        {
            Click(btnMore);
            return this;
        }       

        
        [Obsolete]
        public bool DefaultState()
        {
            return 
                GetVisible(divdateFrom)&&
                GetVisible(divDateTo);
               
        }

        [Obsolete]
        public string GetFromValue()
        {
            return Text(divFromBy);
        }
        [Obsolete]
        public string GetDateTo()
        {
            return GetFieldValue(divDateTo);
        }
        
        [Obsolete]
        public string GetDateFrom()
        {
            return GetFieldValue(divDateFromBy);
        }
       
        [Obsolete]
        public void SetDateTo(int daysCount)
        {
            SetNextDaysOnTheRigth(divDateTo,daysCount);

        }
        [Obsolete]
        public void SetDateFrom(int daysCount)
        {
            SetNextDaysOnTheRigth(divDateFromBy, daysCount);
        }
        public void SetNextMonthDateFrom()
        {
            int weeksInMonth = 4;
            SetWeek(divDateFromBy, weeksInMonth);
        }
        
        [Obsolete]
        public string GetToValue()
        {
            return Text(divTo);
        }

        [Obsolete]
        public void SetSelect(string value)
        {
            SetValueSelect(listBoxHashTag, value);
        }
       
        [Obsolete]
        public string GetSelectElement()
        {
            return GetFieldValue(listBoxHashTag);
        }
        [Obsolete]
        public string GetSelect()
        {
            return Text(divSelect);
        }
        [Obsolete]
        public string GetSelectElementSettingValue()
        {
            return Text(selectSetting);
        }
        [Obsolete]
        public HomeEvent BtnLessClick()
        {
            Click(btnLess);
            return this;
        }

        [Obsolete]
        public FilterByLocation BtnFilterByLocationClick()
        {
           
            Click(btnLocation);
            return new FilterByLocation(driver);
        }
        [Obsolete]
        public bool EnabledSearch()
        {
            return IsEnabled(btnSearch);
        }
        [Obsolete]
        public bool GetEnabledBtnSearchAfterClicking()
        {
            return IsVisible(btnSearch);
        }
        public int GetCountElementSideBar()
        {
            return sideBar.GetNavElCount();
        }        
        public bool IsHomeObject()
        {
           return sideBar.IsContainsPageItemsAsync(BaseInfoData.HomeMenu).Result;
        }

    }
}

