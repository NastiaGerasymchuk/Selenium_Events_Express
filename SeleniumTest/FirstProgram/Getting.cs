using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumTest;
using System;
using System.Linq;

public class Getting
{
    public static string GetByValue(IWebElement element)
    {
       return element.GetAttribute("value");
    }
    public static string GetSelectElement(IWebElement element)
    {
        return new SelectElement(element).AllSelectedOptions.FirstOrDefault().Text;
    }
}
