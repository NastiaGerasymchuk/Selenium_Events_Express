using OpenQA.Selenium;
using SeleniumTest.EventsExpressTests.Pages;
using System;
using System.Linq;

namespace SeleniumTest.EventsExpressTests
{
    public class SocialSharing:BaseClass
    {
        
        private string cssSocialDiv;
        public SocialSharing(IWebDriver driver,int eventNumber):base(driver)
        {
            cssSocialDiv= $"/ html / body / div[{1+eventNumber*2}] / div[3] / ul / li";
        }
        [Obsolete]
        public int GetSharingCount()
        {
            Console.WriteLine(cssSocialDiv);
            string aHref = "/a";
            By cssAhref = By.XPath(cssSocialDiv+aHref);
            var elementHref = driver.FindElements(cssAhref);
            int aHrefCount= elementHref.Count();

            string btn = "/button";
            By cssBtn = By.XPath(cssSocialDiv + btn);
            var elementBtn = driver.FindElements(cssBtn);
            int btnCount = elementBtn.Count();

            return aHrefCount + btnCount;
        }
    }
}
