﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumTest.EventsExpressTests.Data;
using SeleniumTest.EventsExpressTests.Helpers;
using System;
using System.Linq;

namespace SeleniumTest.EventsExpressTests.Pages
{
    public class BaseClass
    {
        protected IWebDriver driver;
        protected WebDriverWait wait;
        protected BaseData BaseData;

        
        public BaseClass(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(BaseData.SecondsWaintings));
        }
        protected By Css(string cssSelector)
        {
            return By.CssSelector(cssSelector);
        }
        protected By Xpath(string xPath)
        {
            return By.XPath(xPath);
        }
        protected By Name(string name)
        {
            return By.Name(name);
        }
        protected By ClassName(string className)
        {
            return By.ClassName(className);
        }
        public HomeEvent GoToBeginPage()
        {
            driver.Navigate().GoToUrl(BaseData.Uri);
            return new HomeEvent(driver);
        }
        protected bool EnabledElement(By by)
        {
           return wait.Until(ExpectedConditions.ElementIsVisible(by)).Enabled;
        }
        protected void CheckElement(By by)
        {
            driver.FindElement(by).Click();
        }
        protected void Click(By by)
        {            
            wait.Until(ExpectedConditions.ElementToBeClickable(by)).Click();
        }
        public int GetElementsCount(By by)
        {
            wait.Until(ExpectedConditions.ElementIsVisible(by));
            var elementName = driver.FindElements(by);
            return elementName.Count();
        }
       
        protected bool GetVisible(By by)
        {
            try
            {
                wait.Until(ExpectedConditions.ElementIsVisible(by));
                IWebElement webElement = driver.FindElement(by);

                return webElement.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        protected void SetInputField(By by,string words)
        {
            wait.Until(ExpectedConditions.ElementIsVisible(by));
            IWebElement webElement = driver.FindElement(by);
            webElement.SendKeys(words);
        }
        protected string GetFieldValue(By by)
        {
            
            wait.Until(ExpectedConditions.ElementIsVisible(by));
            IWebElement webElement = driver.FindElement(by);
            return webElement.GetAttribute("value");
        }
        protected string GetTextArea(By by)
        {

            wait.Until(ExpectedConditions.ElementIsVisible(by));
            IWebElement webElement = driver.FindElement(by);
            return webElement.GetAttribute("innerHTML");
        }
        protected string Text(By by)
        {
            wait.Until(ExpectedConditions.ElementIsVisible(by));
            IWebElement webElement = driver.FindElement(by);
            return webElement.Text;
        }
        protected void SetNextDaysOnTheRigth(By by, int daysCount)
        {
            IWebElement element = driver.FindElement(by);
            element.Click();
            for (int i = 0; i < daysCount; i++)
            {
                element.SendKeys(Keys.ArrowRight);
            }
            element.SendKeys(Keys.Enter);
        }
        protected void SetNextDaysOnDown(By by, int daysCount)
        {
            IWebElement element = driver.FindElement(by);
            element.Click();
            for (int i = 0; i < daysCount; i++)
            {
                element.SendKeys(Keys.ArrowDown);
            }
            element.SendKeys(Keys.Enter);
        }
        protected void SetWeek(By by, int weeksCount)
        {
            IWebElement element = driver.FindElement(by);
            element.Click();
            for (int i = 0; i < weeksCount; i++)
            {
                element.SendKeys(Keys.ArrowDown);
            }
            element.SendKeys(Keys.Enter);
        }
        protected void SetValueSelect(By by,string value)
        {
            wait.Until(ExpectedConditions.ElementIsVisible(by));
            IWebElement webElement = driver.FindElement(by);
            webElement.Click();
            webElement.SendKeys(value);
            webElement.SendKeys(Keys.Enter);
            webElement.SendKeys(Keys.Tab);
        }
        protected void SetValueSelectNumberElement(By by,int number)
        {
            IWebElement webElement = driver.FindElement(by);
            webElement.Click();
            for (int i = 0; i < number; i++)
            {
                by.ArrowDown();
            }
            webElement.SendKeys(Keys.Enter);
            webElement.SendKeys(Keys.Alt);
        }
        protected bool IsEnabled(By by)
        {
            try
            {
                wait.Until(ExpectedConditions.ElementIsVisible(by)).Click();
                return true;
            }
            catch (WebDriverException)
            {
                return false;
            }
        }
        protected bool IsVisible(By by)
        {
            return wait.Until(ExpectedConditions.ElementIsVisible(by)).Enabled;
        }
        protected string GetTitle(By by)
        {
            return wait.Until(ExpectedConditions.ElementIsVisible(by)).GetAttribute("title");
        }
        public void Tab()
        {
            IWebElement webElement = driver.SwitchTo().ActiveElement();
            webElement.SendKeys(Keys.Tab);
        }
        public void Esc()
        {
            IWebElement webElement = driver.SwitchTo().ActiveElement();
            webElement.SendKeys(Keys.Escape);
        }

        protected string GetAttribute(By by, string attributeName)
        {
            return wait.Until(ExpectedConditions.ElementIsVisible(by)).GetAttribute(attributeName);
        }

    }
}