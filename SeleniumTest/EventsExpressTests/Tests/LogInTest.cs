using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumTest.EventsExpressTests.Data;
using SeleniumTest.EventsExpressTests.Models;
using SeleniumTest.EventsExpressTests.Tests;
using System;
namespace SeleniumTest.EventsExpressTests
{
    [TestFixture]
    class LogInTest:BaseTest
    {
        private string errorMessage = "Incorrect login or password";
        private string errorEmail = "Invalid email address";
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
        }

        
        [Test]
        [TestCaseSource(typeof(UserAdminCorrectData))]
        public void ExistedUser_GoToHomeUserAdminPage( User user)
        {
            HomeEvent home = GetHomeObject();
            var registerPage = home.Registration();
            Assert.That(registerPage.GetType() == typeof(RegisterPage), Is.True);

            registerPage.SetEmail(user.Email);
            registerPage.SetPassword(user.Password);
            var userAdminPage = registerPage.LoginBtnClickValidData();
            Assert.That(userAdminPage.GetType() == typeof(UserAdminPage), Is.True);
            Assert.That(userAdminPage.ExistUser_Admin(), Is.True);
        }
        [Obsolete]
        [Test]
        [TestCaseSource(typeof(UserIncorrectData))]
        public void NotExistedUser_GoToHomePage(User user)
        {            
            HomeEvent home = GetHomeObject();
            var registerPage = home.Registration();
            Assert.That(registerPage.GetType() == typeof(RegisterPage), Is.True);

            var res = registerPage.InValidLogin(user.Email, user.Password);
            Assert.That(res.GetType() == typeof(RegisterPage), Is.True);

            var message = res.GetErrorData();
            Assert.That(message, Is.EqualTo(errorMessage));
        }
        [Obsolete]
        [Test]
        [TestCaseSource(typeof(NotCorrectEmailFull))]
        public void NotCorrectEmailwithPassword_GoToHomePage(User user)
        {
            HomeEvent home = GetHomeObject();
            var registerPage = home.Registration();
            Assert.That(registerPage.GetType() == typeof(RegisterPage), Is.True);

            var res = registerPage.InValidLogin(user.Email, user.Password);
            Assert.That(res.GetType() == typeof(RegisterPage), Is.True);

            var message = res.GetErrorEmail();
            Assert.That(message, Is.EqualTo(errorEmail));
        }
        [Obsolete]
        [Test]
        [TestCaseSource(typeof(NotCorrectEmailEmptyPassword))]
        public void NotCorrectEmailwithEmptyPassword_GoToHomePage(User user)
        {
            HomeEvent home = GetHomeObject();
            var registerPage = home.Registration();
            Assert.That(registerPage.GetType() == typeof(RegisterPage), Is.True);

            var res = registerPage.InValidLogin(user.Email, user.Password);
            Assert.That(res.GetType() == typeof(RegisterPage), Is.True);

            var messageEmail = res.GetErrorEmail();
            Assert.That(messageEmail, Is.EqualTo(errorEmail));

            var requiredPassword = res.GetErrorPassword();
            Assert.That(requiredPassword, Is.EqualTo(requiredPassword));
        }
        [TearDown]
        public override void TearDown()
        {
            base.TearDown();
        }
    }
}
