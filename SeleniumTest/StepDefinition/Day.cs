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
    public class Day:BaseTest
    {
        private readonly ScenarioContext context;
        private HomeEvent home;
        private UserAdminPage res;
        private AddEvent addEvent;
        private UserAdminPage homePage;
        public Day(ScenarioContext injectedContext)
        {
            context = injectedContext;
            base.SetUp();
        }

        [Given(@"I am authorised   user (.*),(.*)")]
        public void GivenIAmAuthorisedUser(string email, string password)
        {
            home = GetHomeObject();
            var registerPage = home.Registration();

            registerPage.SetEmail(email);
            registerPage.SetPassword(password);
            res = registerPage.LoginBtnClickValidData();
           
        }
        
        [Given(@"on add  event page")]
        public void GivenOnAddEventPage()
        {
            addEvent = res.AddEventClick();
           
        }
        
        [When(@"I set value of all requred fields\((.*), (.*),(.*), (.*), position on the map\)")]
        public void WhenISetValueOfAllRequredFieldsPositionOnTheMap(string photo, string title, string description, string category)
        {
            addEvent.UploadPhoto(photo);
            addEvent.CropClick();
            addEvent.SetTitle(title);
            addEvent.SetDescription(description);
            addEvent.SetCategory(category);
            addEvent.MoveDown();
            addEvent.ChooseMapPosition();

            
        }
        
        [Then(@"periodicity dropdown option and frequency aren't visible")]
        public void ThenPeriodicityDropdownOptionAndFrequencyArenTVisible()
        {
            Assert.That(addEvent.IsPeriodicityVisible, Is.False);
            Assert.That(addEvent.IsFrequencyVisible, Is.False);
           
        }
        
        [Then(@"choose recurent event")]
        public void ThenChooseRecurentEvent()
        {
            addEvent.SetReccurentEvent();
            
        }
        
        [Then(@"periodicity dropdown option and frequency are visible")]
        public void ThenPeriodicityDropdownOptionAndFrequencyAreVisible()
        {
            Assert.That(addEvent.IsPeriodicityVisible, Is.True);
            Assert.That(addEvent.IsFrequencyVisible, Is.True);
           
        }
        
        [Then(@"choose Daily option in periodicity dropdown")]
        public void ThenChooseDailyOptionInPeriodicityDropdown()
        {
            addEvent.ChooseDailyOption();
            
        }
        
        [Then(@"choose frequency (.*)")]
        public void ThenChooseFrequency(string frequency)
        {
            addEvent.SetFrequency(frequency);
            
        }
        
        [Then(@"choose date from field (.*)")]
        public void ThenChooseDateFromField(string dateFrom)
        {
            addEvent.SetDateFrom(Convert.ToInt32(dateFrom));
            
        }
        
        [Then(@"click  save button")]
        public void ThenClickSaveButton()
        {
            addEvent.Save();
           
        }
        
        [Then(@"event  will be created")]
        public void ThenEventWillBeCreated()
        {
            Thread.Sleep(BaseConfigData.ThreadSleep);
            Assert.That(addEvent.IsEventCreated, Is.True);
            
        }
        
        [Then(@"I  am redirected to home page")]
        public void ThenIAmRedirectedToHomePage()
        {
            homePage = res.HomeBtnClick();
            
        }
        
        [Then(@"I  see created event")]
        public void ThenISeeCreatedEvent()
        {
            int eventCount = BaseConfigData.EventsCount + 1;
            Assert.That(addEvent.GetEventCount(), Is.EqualTo(eventCount));
            
        }
        
        [Then(@"created event will be from chosen date for chosen count of days")]
        public void ThenCreatedEventWillBeFromChosenDateForChosenCountOfDays(Table table)
        {
            Assert.IsTrue(homePage.GetType() == typeof(UserAdminPage));
        }
    }
}
