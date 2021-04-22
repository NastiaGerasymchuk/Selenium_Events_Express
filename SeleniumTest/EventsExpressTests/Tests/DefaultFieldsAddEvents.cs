using NUnit.Framework;
using SeleniumTest.EventsExpressTests;
using SeleniumTest.EventsExpressTests.Data.Events;
using SeleniumTest.EventsExpressTests.Tests;
using SeleniumTest.EventsExpressTests.Models;
using System;
using System.Globalization;
using SeleniumTest.EventsExpressTests.Data.AddEvent;
using SeleniumTest.EventsExpressTests.Data;

namespace SeleniumTest
{
    class DefaultFieldsAddEvents : BaseTest
    {
        [SetUp]
        [Obsolete]
        public override void SetUp()
        {
            base.SetUp();
        }
        
        [TestCaseSource(typeof(DefaultFields))]
        public void DefaultValues1(string email,string password,string date)
        {
            HomeEvent homeEvent = GetHomeObject();
            RegisterPage registerPage = homeEvent.Registration();
            registerPage.SetEmail(email);
            registerPage.SetPassword(password);
            UserAdminPage userAdminPage = registerPage.LoginBtnClickValidData();
            AddEvent addEvent = userAdminPage.AddEventClick();
            Assert.That(addEvent.IsPhotoVisible, Is.False);
            Assert.That(addEvent.GetTitle, Is.Empty);
            Assert.That(addEvent.GetDescription, Is.Empty);
            Assert.That(addEvent.GetMaxParticipants, Is.Empty);
            Assert.That(addEvent.IsCheckedPublicEvent, Is.False);
            Assert.That(addEvent.IsCheckedRecurentEvent, Is.False);
            Assert.That(addEvent.GetDateFrom, Is.EqualTo(date));
            Assert.That(addEvent.GetDescription, Is.Empty);
            Assert.That(addEvent.GetCategory, Is.Empty);
            Assert.That(addEvent.IsMapChecked, Is.True);
            Assert.That(addEvent.IsOnlineChecked, Is.False);
            Assert.That(addEvent.IsChoosenMapPosition, Is.False);
            Assert.That(addEvent.IsCollapsedEventInventories, Is.True);
        }
        [TestCaseSource(typeof(EventForAdding))]
        public void AddEvent(Event eventForAdding, string email, string password, int eventOrder, string photoPath)
        {

            string title = eventForAdding.Title;            
            string categoryName = eventForAdding.Category;
            string description = eventForAdding.Description;
            HomeEvent home = GetHomeObject();
            var registerPage = home.Registration();
            registerPage.SetEmail(email);
            registerPage.SetPassword(password);
            UserAdminPage res = registerPage.LoginBtnClickValidData();
            var addEvent = res.AddEventClick();
           
            addEvent.UploadPhoto(photoPath);
            addEvent.CropClick();

            addEvent.SetTitle(title);
            addEvent.SetDescription(description);
            addEvent.SetCategory(categoryName);           
            addEvent.MoveDown();
            //Assert.That(addEvent.IsNotFilledMapPosition, Is.True);
            addEvent.ChooseMapPosition();
            Assert.That(addEvent.IsNotFilledMapPosition, Is.False);
            addEvent.Save();
            Assert.That(addEvent.IsEventCreated, Is.True);
            var homePage = res.HomeBtnClick();
            Assert.IsTrue(homePage.GetType() == typeof(UserAdminPage));
        }
        [TestCaseSource(typeof(EventForAdding))]
        public void AddOnlineEvent(Event eventForAdding, string email, string password, int eventOrder, string photoPath)
        {

            string title = eventForAdding.Title;            
            string onlinePath = eventForAdding.OnlinePath;            
            string categoryName = eventForAdding.Category;
            string description = eventForAdding.Description;
            HomeEvent home = GetHomeObject();
            var registerPage = home.Registration();
            Assert.That(registerPage.GetType() == typeof(RegisterPage), Is.True);

            registerPage.SetEmail(email);
            registerPage.SetPassword(password);
            UserAdminPage res = registerPage.LoginBtnClickValidData();
            var addEvent = res.AddEventClick();
            addEvent.UploadPhoto(photoPath);
            addEvent.CropClick();
            addEvent.SetTitle(title);
            addEvent.SetDescription(description);
            addEvent.SetCategory(categoryName);
            //Assert.That(addEvent.IsNotFilledMapPosition, Is.True);
            addEvent.SetOnlineEvent();
            //Assert.That(addEvent.IsNotFilledOnlinePosition, Is.True);
            addEvent.SetOnlinePath(onlinePath);
            Assert.That(addEvent.IsNotFilledOnlinePosition, Is.False);
            addEvent.Save();
            Assert.That(addEvent.IsEventCreated, Is.True);
            var homePage = res.HomeBtnClick();
            Assert.IsTrue(homePage.GetType() == typeof(UserAdminPage));

        }
        [Test]
        public void ImpossibilityCreateEvent()
        {            
            HomeEvent home = GetHomeObject();
            UserAdminPage userAdmin = new UserAdminPage(this.driver);
            Assert.That(userAdmin.IsVisibleAddEvent, Is.False);
        }

        [TestCaseSource(typeof(EventForAdding))]
        public void SetPublicEvent(Event eventForAdding, string email, string password, int eventOrder, string photoPath)
        {

            string title = eventForAdding.Title;
            string onlinePath = eventForAdding.OnlinePath;
            string categoryName = eventForAdding.Category;
            string description = eventForAdding.Description;
            int eventCount = BaseData.EventsCount + 1;
            HomeEvent home = GetHomeObject();
            var registerPage = home.Registration();
            Assert.That(registerPage.GetType() == typeof(RegisterPage), Is.True);

            registerPage.SetEmail(email);
            registerPage.SetPassword(password);
            UserAdminPage res = registerPage.LoginBtnClickValidData();
            var addEvent = res.AddEventClick();
            addEvent.UploadPhoto(photoPath);
            addEvent.CropClick();
            addEvent.SetTitle(title);
            addEvent.SetDescription(description);
            addEvent.SetCategory(categoryName);            
            //Assert.That(addEvent.IsNotFilledMapPosition, Is.True);
            addEvent.SetOnlineEvent();
            //Assert.That(addEvent.IsNotFilledOnlinePosition, Is.True);
            addEvent.SetOnlinePath(onlinePath);
            addEvent.SetPublicEvent();
            addEvent.Save();
            Assert.That(addEvent.IsEventCreated, Is.True);
            var homePage = res.HomeBtnClick();
            Assert.That(addEvent.GetEventCount(), Is.EqualTo(eventCount));
            Assert.IsTrue(homePage.GetType() == typeof(UserAdminPage));

        }

        [TearDown]
        public override void TearDown()
        {
            base.TearDown();
        }
    }
}
