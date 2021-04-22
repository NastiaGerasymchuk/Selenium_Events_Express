
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumTest.EventsExpressTests;
using SeleniumTest.EventsExpressTests.Tests;
using System;
using System.Globalization;
using TechTalk.SpecFlow;

namespace SeleniumTest.StepDefinition
{
    [Binding]
    public class DefaultValues : BaseTest
    {
        HomeEvent homeEvent;
        RegisterPage registerPage;
        UserAdminPage userAdminPage;
        AddEvent addEvent;
        private readonly ScenarioContext context;
        public DefaultValues(ScenarioContext injectedContext)
        {
            context = injectedContext;
            base.SetUp();
        }

        [Given(@"unauthorised user")]
        public void GivenUnauthorisedUser()
        {
            homeEvent = GetHomeObject();
        }

        [When(@"I authorised with (.*),(.*)")]
        public void WhenIAuthorisedWith(string email, string password)
        {
            registerPage = homeEvent.Registration();
            registerPage.SetEmail(email);
            registerPage.SetPassword(password);
            userAdminPage = registerPage.LoginBtnClickValidData();
        }

        [When(@"go to add event page")]
        public void WhenGoToAddEventPage()
        {
            addEvent=userAdminPage.AddEventClick();
        }

        [Then(@"I see photo field is empty")]
        public void ThenISeePhotoFieldIsEmpty()
        {
            Assert.That(addEvent.IsPhotoVisible, Is.False);

        }

        [Then(@"title is empty")]
        public void ThenTitleIsEmpty()
        {
            Assert.That(addEvent.GetTitle, Is.Empty);
        }

        [Then(@"max count of participants is empty")]
        public void ThenMaxCountOfParticipantsIsEmpty()
        {
            Assert.That(addEvent.GetMaxParticipants, Is.Empty);
        }

        [Then(@"reccurent event field is unchecked")]
        public void ThenReccurentEventFieldIsUnchecked()
        {
            Assert.That(addEvent.IsCheckedRecurentEvent, Is.False);
        }

        [Then(@"public field is unchecked")]
        public void ThenPublicFieldIsUnchecked()
        {
            Assert.That(addEvent.IsCheckedPublicEvent, Is.False);
        }

        [Then(@"date field is current date")]
        public void ThenDateFieldIsCurrentDate()
        {
            string date = DateTime.Now.ToString("d", DateTimeFormatInfo.InvariantInfo);
            Assert.That(addEvent.GetDateFrom, Is.EqualTo(date));
        }

        [Then(@"description is empty")]
        public void ThenDescriptionIsEmpty()
        {
            Assert.That(addEvent.GetDescription, Is.Empty);
        }

        [Then(@"hashtags field is empty")]
        public void ThenHashtagsFieldIsEmpty()
        {

            Assert.That(addEvent.GetCategory, Is.Empty);

        }

        [Then(@"map option is chosed")]
        public void ThenMapOptionIsChosed()
        {
            Assert.That(addEvent.IsMapChecked, Is.True);

        }

        [Then(@"online option is unchosed")]
        public void ThenOnlineOptionIsUnchosed()
        {
            Assert.That(addEvent.IsOnlineChecked, Is.False);

        }

        [Then(@"position on the map field isn't chosen")]
        public void ThenPositionOnTheMapFieldIsnTChosen()
        {
            Assert.That(addEvent.IsChoosenMapPosition, Is.False);

        }

        [Then(@"list of inventories is collapsed")]
        public void ThenListOfInventoriesIsCollapsed()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
            Assert.That(addEvent.IsCollapsedEventInventories, Is.True);
        }
        [Then(@"quit browser")]
        public void ThenQuitBrowser()
        {
            driver.Quit();
        }
    }
}
