using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public List<string> GetNavElText()
        {
            return GetTextFromElements(nav);
        }
        public bool IsCurrentPage(List<string> pageItems)
        {
            var res = GetNavElText();
            var masterToken = res.Select(t => t.Trim()).ToList();

            List<string> matching = masterToken.Intersect(pageItems).ToList();

            return matching.Count == pageItems.Count;
        }
    }
}
