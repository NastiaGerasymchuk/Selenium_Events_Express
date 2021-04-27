using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace SeleniumTest.EventsExpressTests.Pages
{
    class SideBar:BaseClass
    {
        //"#main > div.events-container > div> div.col-12";
        //#main > div.events-container > div > div:nth-child(3)
        //#root > div.left-sidebar-closed.left-sidebar > nav > ul > li:nth-child(1) > a > span > span
        //#root > div.left-sidebar-closed.left-sidebar > nav > ul > li.sidebar-header
        
        private string cssNav = "#root > div.left-sidebar-closed.left-sidebar > nav > ul li.sidebar-header";
        private By nav;
        public SideBar(IWebDriver driver) : base(driver)
        {
            nav = Css(cssNav);
           
        }
        public int GetNavElCount()
        {
            return GetElementsCount(nav);
        }

        [Obsolete]
        public List<string> GetNavElText()
        {
            return GetTextFromElements(nav);
        }

        [Obsolete]
        public async Task<bool> IsContainsPageItemsAsync(List<string> pageItems)
        {
            var res = GetNavElText();
            var eq=  res.Select(t => t.Replace("0\r\n", "")).Select(t => t.Trim()).Intersect(pageItems).Count().Equals(pageItems.Count);
            return await Task.FromResult(eq);
        }
    }
}
