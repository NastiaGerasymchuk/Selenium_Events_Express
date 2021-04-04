using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumTest;
using System;

public static class Selection
{
    public static void SendKeys(this IWebElement element, string value)
    {
        
        element.SendKeys(value);
    }

    public static void ClickElement(this IWebElement element)
    {
        element.Click();
    }
    public static void SelectElements(this IWebElement element, string value)
    {
        new SelectElement(element).SelectByText(value);
    }
}
