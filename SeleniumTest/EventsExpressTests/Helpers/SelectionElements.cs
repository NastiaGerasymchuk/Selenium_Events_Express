using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTest.EventsExpressTests.Helpers
{
   public static class SelectionElements
    {
        private static IWebDriver driver = new ChromeDriver(@"C:\Users\Admin\Desktop");
        public static void Click(this By by)
        {
            IWebElement webElement = driver.FindElement(by);
            webElement.Click();
        }
        public static void ClickRegister(By by)
        {
            IWebElement webElement = driver.FindElement(by);
            webElement.Click();
            //driver.Close();
        }
        public static string GetValue(this By by)
        {
            IWebElement webElement = driver.FindElement(by);
            return webElement.GetAttribute("value");
        }
        public static void SendKeys(this By by,string text)
        {
            IWebElement webElement = driver.FindElement(by);
            webElement.SendKeys(text);
        }
        public static void Enter(this By by)
        {
            IWebElement webElement = driver.FindElement(by);
            webElement.SendKeys(Keys.Enter);
        }
        public static void Tab(this By by)
        {
            IWebElement webElement = driver.FindElement(by);
            webElement.SendKeys(Keys.Tab);
        }
        public static void ArrowDown(this By by)
        {
            IWebElement webElement = driver.FindElement(by);
            webElement.SendKeys(Keys.ArrowDown);
        }
        public static void Alt(this By by)
        {
            IWebElement webElement = driver.FindElement(by);
            webElement.SendKeys(Keys.Alt);
        }
        public static void Scc(this By by,string cssSelector)
        {
            by = By.CssSelector(cssSelector);
        }
    }
}
