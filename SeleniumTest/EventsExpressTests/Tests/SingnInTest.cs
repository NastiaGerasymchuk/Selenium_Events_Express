using NUnit.Framework;
using SeleniumTest.EventsExpressTests.Tests;
using System;

namespace SeleniumTest
{
    [TestFixture]
    class SingnInTest: BaseTest
    {
        private const string IncorrectLoginPassword = "Incorrect login or password";

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
        }

        [Test]
        [TestCase("admin@gmail.com", "1qaz1qaz")]
        public void ValidLogin(string email, string password)
        {
            HomeEvent home = GetHomeObject();
            RegisterPage registerPage=  home.Registration();
             var res = registerPage.ValidLogin(email,password);
            Assert.IsTrue(res.GetType() == typeof(HomeEvent));
        }
        [Test]
        [TestCase("admin1@gmail.com", "1qaz1qaz")]
        public void InValidLogin(string email, string password)
        {
            HomeEvent home = GetHomeObject();
            RegisterPage registerPage = home.Registration();
            var res = registerPage.InValidLogin(email, password);
            Assert.That(res.GetErrorData(), Is.EqualTo(IncorrectLoginPassword));
            Assert.IsTrue(res.GetType() == typeof(RegisterPage));
        }
        [TearDown]
        public override void TearDown()
        {
            base.TearDown();
        }
    }
}
