using NUnit.Framework;
using SeleniumTest.EventsExpressTests;
using SeleniumTest.EventsExpressTests.Tests;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using SeleniumTest.EventsExpressTests.Data;

namespace SeleniumTest.StepDefinition
{
    [Binding]
    public class Online:BaseTest
    {
        private readonly ScenarioContext context;
        private HomeEvent home;
        private UserAdminPage res;
        private AddEvent addEvent;
        public Online(ScenarioContext injectedContext)
        {
            context = injectedContext;
            base.SetUp();
        }
        [Given(@"I am authorised  user (.*),(.*)")]
        public void GivenIAmAuthorisedUser(string email, string password)
        {
            home = GetHomeObject();
            var registerPage = home.Registration();
            registerPage.SetEmail(email);
            registerPage.SetPassword(password);
            res = registerPage.LoginBtnClickValidData();
        }
        
        [Given(@"on  add event page")]
        public void GivenOnAddEventPage()
        {
            addEvent = res.AddEventClick();
        }
        
        [When(@"I set   photo field (.*)")]
        public void WhenISetPhotoField(string photoPath)
        {
            addEvent.UploadPhoto(photoPath);
            addEvent.CropClick();
        }
        
        [When(@"type  title fiele (.*)")]
        public void WhenTypeTitleFiele(string title)
        {
            addEvent.SetTitle(title);
        }
        
        [When(@"type  description  field (.*)")]
        public void WhenTypeDescriptionField(string description)
        {
            addEvent.SetDescription(description);
        }
        
        [When(@"choose  category  field (.*)")]
        public void WhenChooseCategoryField(string categoryName)
        {
            addEvent.SetCategory(categoryName);
        }
        
        [When(@"map   field lights red")]
        public void WhenMapFieldLightsRed()
        {
            //Assert.That(addEvent.IsNotFilledMapPosition, Is.True);
        }

        [When(@"choose online option")]
        public void WhenChooseOnlineOption()
        {
            addEvent.SetOnlineEvent();
        }
        
        [Then(@"online   field ligths red")]
        public void ThenOnlineFieldLigthsRed()
        {
            //Assert.That(addEvent.IsNotFilledOnlinePosition, Is.True);
        }

        [Then(@"type online  field (.*)")]
        public void ThenTypeOnlineField(string onlinePath)
        {
            addEvent.SetOnlinePath(onlinePath);
        }
        
        [Then(@"online  field  doesn't ligth red")]
        public void ThenOnlineFieldDoesnTLigthRed()
        {
            Assert.That(addEvent.IsNotFilledOnlinePosition, Is.False);
        }
        
        [Then(@"click  save   button")]
        public void ThenClickSaveButton()
        {
            addEvent.Save();
        }
        
        [Then(@"event   will be created")]
        public void ThenEventWillBeCreated()
        {
            Thread.Sleep(BaseConfigData.ThreadSleep);
            Assert.That(addEvent.IsEventCreated, Is.True);
        }
        
        [Then(@"user   is redirected to home page")]
        public void ThenUserIsRedirectedToHomePage(Table table)
        {
            var homePage = res.HomeBtnClick();
            Assert.IsTrue(homePage.GetType() == typeof(UserAdminPage));
            driver.Quit();
        }
    }
}
