using NUnit.Framework;
using SeleniumTest.EventsExpressTests;
using SeleniumTest.EventsExpressTests.Data.Events;
using SeleniumTest.EventsExpressTests.Tests;
using SeleniumTest.EventsExpressTests.Models;
using System;

namespace SeleniumTest
{
    class AddEventTest:BaseTest
    {
        [SetUp]
        [Obsolete]
        public override void SetUp()
        {
            base.SetUp();
        }
        [Obsolete]
        [TestCaseSource(typeof(EventForAdding))]
        public void AddEvent(Event eventForAdding,string email, string password, int eventOrder,string photoPath)
        {

            string title = eventForAdding.Title;
            string maxCountParticipants = eventForAdding.Participants;
            string onlinePath = eventForAdding.OnlinePath;
            int nextDays = 3;
            string categoryName = eventForAdding.Category;
            string description = eventForAdding.Description;
            HomeEvent home = GetHomeObject();
            var registerPage = home.Registration();
            Assert.That(registerPage.GetType() == typeof(RegisterPage), Is.True);

            registerPage.SetEmail(email);
            registerPage.SetPassword(password);
            UserAdminPage res =registerPage.LoginBtnClickValidData();
            var addEvent = res.AddEventClick();
            Assert.That(addEvent.GetType() == typeof(AddEvent), Is.True);
            addEvent.UploadPhoto(photoPath);

            Assert.That(addEvent.CropVisible, Is.True);
            addEvent.CropClick();

            addEvent.SetTitle(title);
            Assert.That(addEvent.GetTitle(), Is.EqualTo(title));

            addEvent.SetMaxParticipants(maxCountParticipants);
            Assert.That(addEvent.GetMaxParticipants, Is.EqualTo(maxCountParticipants));

            addEvent.SetPublicEvent();

            addEvent.SetOnlineEvent();
            addEvent.SetOnlinePath(onlinePath);
            Assert.That(addEvent.GetOnlinePath, Is.EqualTo(onlinePath));

            addEvent.SetDateFrom(nextDays);
            Assert.That(addEvent.IsVisibleDateTo, Is.True);
            
            addEvent.SetDateTo(nextDays);

            addEvent.SetCategory(categoryName);
            Assert.That(addEvent.GetCategory, Is.EqualTo(categoryName));

            addEvent.SetDescription(description);
            Assert.That(addEvent.GetDescription, Is.EqualTo(description));

            addEvent.Save();

            var homePage=res.HomeBtnClick();
            Assert.That(homePage.GetType() == typeof(UserAdminPage), Is.True);


        }

        [TearDown]
        public override void TearDown()
        {
            base.TearDown();
        }
    }
}
