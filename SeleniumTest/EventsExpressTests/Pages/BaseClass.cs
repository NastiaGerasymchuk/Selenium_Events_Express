using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumTest.EventsExpressTests.Data;
using SeleniumTest.EventsExpressTests.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SeleniumTest.EventsExpressTests.Pages
{
    public class BaseClass
    {
        protected IWebDriver driver;
        protected WebDriverWait wait;
        protected BaseConfigData BaseData;

        
        public BaseClass(IWebDriver driver)
        {
            this.driver = driver;
            //this.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(BaseConfigData.SecondsWaintings);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(BaseConfigData.SecondsWaintings));
        }
        protected By Css(string cssSelector)
        {
            return By.CssSelector(cssSelector);
        }
        protected By Id(string cssSelector)
        {
            return By.Id(cssSelector);
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
            driver.Navigate().GoToUrl(BaseConfigData.Uri);
            return new HomeEvent(driver);
        }
        protected bool EnabledElement(By by)
        {
           return wait.Until(ExpectedConditions.ElementIsVisible(by)).Enabled;
        }
        protected void CheckElement(By by)
        {
             //wait.Until(ExpectedConditions.ElementToBeClickable(by)).Click();
            driver.FindElement(by).Click();
        }

        [Obsolete]
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
        public List<string> GetTextFromElements(By by)
        {
            //wait.Until(ExpectedConditions.ElementIsVisible(by));
            List<string> textRes = new List<string>();
            var elementName = driver.FindElements(by);
            foreach(IWebElement webElement in elementName)
            {
                textRes.Add(webElement.Text);
            }
            return textRes;
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
        public bool HasClass(IWebElement el,string className)
        {

            return el.GetAttribute("class").Split(' ').Contains(className);
        }
        public bool HasStyle(IWebElement el, string styleName)
        {

            return el.GetAttribute("style").Split(' ').Contains(styleName);
        }

        public bool MoveDown()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(BaseConfigData.SecondsWaintings);
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
           
            return true;
        }
        public bool MoveUp()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(BaseConfigData.SecondsWaintings);
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollTo(0, -document.body.scrollHeight)");
            return true;
        }
        public void Refresh()
        {
            driver.Navigate().Refresh();
        }

    }
}
