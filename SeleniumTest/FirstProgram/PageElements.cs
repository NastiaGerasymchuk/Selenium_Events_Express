using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

namespace SeleniumTest
{
   public class PageElements
    {
        [Obsolete]
        public PageElements()
        {
            PageFactory.InitElements(Driver.driver, this);
        }

        
        [FindsBy(How = How.Id, Using = "TitleId")]
        private IWebElement _selectElement;
        
        [FindsBy(How = How.Id, Using = "Initial")]
        private IWebElement _initiaTxt;

        [FindsBy(How = How.Name, Using = "FirstName")]
        private IWebElement _firstName;

        [FindsBy(How = How.Name, Using = "MiddleName")]
        private IWebElement _middleName;

        [FindsBy(How = How.Name, Using = "Female")]
        private IWebElement _radioElement;


        [FindsBy(How = How.Name, Using = "Hindi")]
        private IWebElement _checkBoxElement;

        public void SetUser(string initial, string firstName, string middleName,string selectValue)
        {
            _initiaTxt.SendKeys(initial);
            _firstName.SendKeys(firstName);
            _middleName.SendKeys(middleName);
            _checkBoxElement.ClickElement();
            _radioElement.ClickElement();
            _selectElement.SelectElements(selectValue);
        }

      

    }
}
