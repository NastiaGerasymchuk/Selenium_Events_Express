using NUnit.Framework;
using SeleniumTest.EventsExpressTests;
using SeleniumTest.EventsExpressTests.Tests;
using TechTalk.SpecFlow;
using SeleniumTest.EventsExpressTests.Data;
using System.Threading;

namespace SeleniumTest.StepDefinition
{
    [Binding]
    public class Public:BaseTest
    {
        private readonly ScenarioContext context;
        private HomeEvent home;
        private UserAdminPage res;
        private AddEvent addEvent;
        private UserAdminPage homePage;
        public Public(ScenarioContext injectedContext)
        {
            context = injectedContext;
            base.SetUp();
        }
        [Given(@"I am authorised user (.*),(.*)")]
        public void GivenIAmAuthorisedUser(string email, string password)
        {           
            home = GetHomeObject();
            var registerPage = home.Registration();
            registerPage.SetEmail(email);
            registerPage.SetPassword(password);
            res = registerPage.LoginBtnClickValidData();           
        }
        
        [Given(@"on add event page")]
        public void GivenOnAddEventPage()
        {
            addEvent=res.AddEventClick();
           
        }
        
        [When(@"I set valid values of all requred fields(.*), (.*),(.*), (.*), position on the map\)")]
        public void WhenISetValidValuesOfAllRequredFieldsPositionOnTheMap(string photo, string title, string description, string category)
        {
            addEvent.UploadPhoto(photo);
            addEvent.CropClick();
            addEvent.SetTitle(title);
            addEvent.SetDescription(description);
            addEvent.SetCategory(category);
            addEvent.ChooseMapPosition();
        }
        
        [When(@"choose pubic event")]
        public void WhenChoosePubicEvent()
        {
            addEvent.SetPublicEvent();
            
        }
        
        [When(@"click save button")]
        public void WhenClickSaveButton()
        {
            addEvent.Save();
            
        }
        
        [Then(@"event will be created")]
        public void ThenEventWillBeCreated()
        {
            Thread.Sleep(BaseData.ThreadSleep);
            Assert.That(addEvent.IsEventCreated, Is.True);
           
        }
        
        [Then(@"I am redirected to home page")]
        public void ThenIAmRedirectedToHomePage()
        {
            homePage = res.HomeBtnClick();
            
        }
        
        [Then(@"I see created event")]
        public void ThenISeeCreatedEvent()
        {
            int eventCount = BaseData.EventsCount + 1;
            Assert.That(addEvent.GetEventCount(), Is.EqualTo(eventCount));
            Assert.IsTrue(homePage.GetType() == typeof(UserAdminPage));
        }
        
        [Then(@"Every users can join to event without my approving")]
        public void ThenEveryUsersCanJoinToEventWithoutMyApproving()
        {
            
            Assert.IsTrue(homePage.GetType() == typeof(UserAdminPage));
            driver.Quit();
        }
    }
}
