using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace SeleniumTest.EventsExpressTests
{
    public class FilterByLocationTest
    {
        private IWebDriver driver;
        private HomeEvent homeEvent;
        private string URL = "https://localhost:44344/home/events?page=1&status=active";
        private string filterTitle= "Filter by location";
        private string radiusValue = "9000";

        [SetUp]
        [Obsolete]
        public void SetUp()
        {
            driver = new ChromeDriver(@"C:\Users\Admin\Desktop");
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(URL);
            homeEvent = new HomeEvent(driver);
        }
        [Test]
        [Obsolete]
        public void FilterByLocation_ExistingTitle()
        {
            var resLess = homeEvent.BtnMoreClick();
            var resFilerClick = resLess.BtnFilterByLocationClick();

            Assert.That(resFilerClick.GetTitleFilter(), Is.EqualTo(filterTitle));
        }

        [Test]
        [Obsolete]
        public void FilterByLocation_ExistingPage()
        {
            var resLess = homeEvent.BtnMoreClick();
            var resFilerClick = resLess.BtnFilterByLocationClick();

            Assert.That(resFilerClick.GetType() == typeof(FilterByLocation), Is.True);
        }

        [Test]
        [Obsolete]
        public void FilterByLocation_ExistingSetRadius()
        {
            var resLess = homeEvent.BtnMoreClick();
            var resFilerClick = resLess.BtnFilterByLocationClick();
            resFilerClick.SetRadiusValue(radiusValue);

            Assert.That(resFilerClick.GetRadiusValue(), Is.EqualTo(radiusValue));
        }
        [Test]
        [Obsolete]
        public void FilterByLocation_ClearRadius()
        {
            var resLess = homeEvent.BtnMoreClick();
            var resFilerClick = resLess.BtnFilterByLocationClick();
            resFilerClick.ClearRadiusValue();
            Assert.That(resFilerClick.GetRadiusValue(), Is.EqualTo(string.Empty));

        }
        [Test]
        [Obsolete]
        public void ClickCanceBtn_FilterByLocation()
        {
            var resLess = homeEvent.BtnMoreClick();
            var resFilerClick = resLess.BtnFilterByLocationClick();
            resFilerClick.ClickCancelBtn();

            Assert.That(resFilerClick.GetType()==typeof(FilterByLocation));

        }
        [Test]
        [Obsolete]
        public void ClickFilterBtn_Homeevent()
        {
            var resLess = homeEvent.BtnMoreClick();
            var resFilerClick = resLess.BtnFilterByLocationClick();
            var resHome= resFilerClick.ClickFilterBtn();

            Assert.That(resHome.GetType() == typeof(HomeEvent));

        }
        [TearDown]
        public void TearDown()
        {
            //driver.Close();
        }
    }
}
