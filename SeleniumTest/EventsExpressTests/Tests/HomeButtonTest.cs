using NUnit.Framework;
using SeleniumTest.EventsExpressTests.Tests;
using System;

namespace SeleniumTest.EventsExpressTests
{
    public class HomeButtonTest:BaseTest
    {
        private const string EmptyResult = "No Results";
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
        }
        [Test]
        [Obsolete]
        public void HomeBtn_Click_HomePage()
        {

            HomeEvent homeEvent = GetHomeObject();
            var res= homeEvent.ClickHomeBtn();
            Assert.IsTrue(res.GetType() == typeof(HomeEvent));
            Assert.That(res.SearchResult(), Is.EqualTo(EmptyResult));
        }
        [Test]
        [Obsolete]
        public void ResultText_NoResult()
        {

            HomeEvent homeEvent = GetHomeObject();
            Assert.That(homeEvent.SearchResult(), Is.EqualTo(EmptyResult));
        }
        [Test]
        [Obsolete]
        public void DefaultStateTest()
        {
            HomeEvent homeEvent = GetHomeObject();
            Assert.That(homeEvent.DefaultState(), Is.False);
        }
        [Test]
        [Obsolete]
        public void DefaultStateTest1()
        {
            HomeEvent homeEvent = GetHomeObject();
            homeEvent = homeEvent.BtnMoreClick();
            Assert.That(homeEvent.DefaultState(), Is.True);
        }
        [TearDown]
        public override void TearDown()
        {
            base.TearDown();
        }
    }
}
