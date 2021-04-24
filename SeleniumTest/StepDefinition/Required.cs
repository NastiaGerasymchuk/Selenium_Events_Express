using NUnit.Framework;
using SeleniumTest.EventsExpressTests;
using SeleniumTest.EventsExpressTests.Models;
using SeleniumTest.EventsExpressTests.Tests;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using SeleniumTest.EventsExpressTests.Data;
namespace SeleniumTest.StepDefinition
{
    [Binding]
    public class Required:BaseTest
    {
        private readonly ScenarioContext context;
        private HomeEvent home;
        private UserAdminPage res;
        private AddEvent addEvent;
        public Required(ScenarioContext injectedContext)
        {
            context = injectedContext;
            base.SetUp();
        }
        [Given(@"unauthorised  user")]
        public void GivenUnauthorisedUser()
        {
            home = GetHomeObject();
        }
        
        [When(@"I   authorised   with")]
        public void WhenIAuthorisedWith(Table table)
        {
            var user = table.CreateInstance<User>();
            var registerPage = home.Registration();
            registerPage.SetEmail(user.Email);
            registerPage.SetPassword(user.Password);
            res = registerPage.LoginBtnClickValidData();
        }
        
        [When(@"go   to add  event page")]
        public void WhenGoToAddEventPage()
        {
            addEvent = res.AddEventClick();
        }
        
        [When(@"I set photo  field (.*)")]
        public void WhenISetPhotoField(string photoPath)
        {
            addEvent.UploadPhoto(photoPath);
            addEvent.CropClick();
        }
        
        [When(@"type  title field (.*)")]
        public void WhenTypeTitleField(string title)
        {
            addEvent.SetTitle(title);
        }
        
        [When(@"type description field  (.*)")]
        public void WhenTypeDescriptionField(string description)
        {
            addEvent.SetDescription(description);
        }
        
        [When(@"choose category field (.*)")]
        public void WhenChooseCategoryField(string categoryName)
        {
            addEvent.SetCategory(categoryName);
        }
        
        [Then(@"map field ligths red")]
        public void ThenMapFieldLigthsRed()
        {
            addEvent.MoveDown();
            //Assert.That(addEvent.IsNotFilledMapPosition, Is.True);    
        }

        [Then(@"choose position on the map field")]
        public void ThenChoosePositionOnTheMapField()
        {
            addEvent.ChooseMapPosition();
        }
        
        [Then(@"map doesn't ligth red")]
        public void ThenMapDoesnTLigthRed()
        {
            Assert.That(addEvent.IsNotFilledMapPosition, Is.False);
        }
        
        [Then(@"click save button")]
        public void ThenClickSaveButton()
        {
            addEvent.Save();
        }
        
        [Then(@"event will  be created")]
        public void ThenEventWillBeCreated()
        {
            Thread.Sleep(BaseData.ThreadSleep);
            Assert.That(addEvent.IsEventCreated, Is.True);
        }
        
        [Then(@"user is redirected to home page")]
        public void ThenUserIsRedirectedToHomePage()
        {
            var homePage = res.HomeBtnClick();
            Assert.IsTrue(homePage.GetType() == typeof(UserAdminPage));
        }
        
        [Then(@"quit  browser")]
        public void ThenQuitBrowser()
        {
            driver.Quit();
        }
    }
}
