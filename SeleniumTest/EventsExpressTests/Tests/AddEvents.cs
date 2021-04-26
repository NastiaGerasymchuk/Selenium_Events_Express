using NUnit.Framework;
using SeleniumTest.EventsExpressTests;
using SeleniumTest.EventsExpressTests.Data.Events;
using SeleniumTest.EventsExpressTests.Tests;
using SeleniumTest.EventsExpressTests.Models;
using System;
using SeleniumTest.EventsExpressTests.Data;
using System.Threading;

namespace SeleniumTest
{
    class DefaultFieldsAddEvents : BaseTest
    {
        private UserAdminPage userAdminPage;
        private HomeEvent homeEvent;
        [SetUp]
        [Obsolete]        
        public override void SetUp()
        {
            base.SetUp();
            homeEvent = GetHomeObject();
            userAdminPage = homeEvent.Login(BaseInfoData.User);

        }
        private void SetRequredFields(string photoPath,string title,string description,string categoryName, AddEvent addEvent)
        {
            addEvent.UploadPhoto(photoPath);
            addEvent.CropClick();

            addEvent.SetTitle(title);
            addEvent.SetDescription(description);
            addEvent.SetCategory(categoryName);
            
        }
        private int GetPrevEvent(HomeEvent homeEvent)
        {
            int eventPrevCount = homeEvent.GetEventcountOnLastPage();
            if (eventPrevCount == BaseElementData.MaxEventOnPage)
            {
                eventPrevCount = 0;
            }
            return eventPrevCount;
        }

        private bool Default(AddEvent addEvent)
        {
            string empty = string.Empty;
            string today = BaseInfoData.Today;
            
            addEvent.MoveUp();
            return  !addEvent.IsPresentAddedPhoto() &&
                    addEvent.GetTitle().Equals(empty)&&
                    addEvent.GetDescription().Equals(empty) &&
                    addEvent.MoveDown() &&
                    addEvent.GetMaxParticipants().Equals(empty) &&
                    !addEvent.IsCheckedPublicEvent() &&
                    !addEvent.IsCheckedRecurentEvent() &&
                    addEvent.GetDateFrom().Equals(today) &&
                    addEvent.GetDescription().Equals(empty) &&
                    addEvent.GetCategory().Equals(empty) &&
                    addEvent.IsMapChecked() &&
                    !addEvent.IsOnlineChecked() &&
                    !addEvent.IsChoosenMapPosition() &&
                    addEvent.IsCollapsedEventInventories();
        }
       
       
        [Test]
        public void DefaultValues()
        {
            string today = BaseInfoData.Today;
            AddEvent addEvent = userAdminPage.AddEventClick();
            Assert.Multiple(() =>
            {
                Assert.That(addEvent.IsPresentAddedPhoto, Is.False);
                Assert.That(addEvent.GetTitle, Is.Empty);
                Assert.That(addEvent.GetDescription, Is.Empty);
                Assert.That(addEvent.GetMaxParticipants, Is.Empty);
                Assert.That(addEvent.IsCheckedPublicEvent, Is.False);
                Assert.That(addEvent.IsCheckedRecurentEvent, Is.False);
                Assert.That(addEvent.GetDateFrom, Is.EqualTo(today));
                Assert.That(addEvent.GetDescription, Is.Empty);
                Assert.That(addEvent.GetCategory, Is.Empty);
                Assert.That(addEvent.IsMapChecked, Is.True);
                Assert.That(addEvent.IsOnlineChecked, Is.False);
                Assert.That(addEvent.IsChoosenMapPosition, Is.False);
                Assert.That(addEvent.IsCollapsedEventInventories, Is.True);
            });
        }
        [TestCaseSource(typeof(AddRequiredEvent))]
        public void AddEventWithOnlyRequiredFields(Event eventForAdding, string photoPath)
        {
            string title = eventForAdding.Title;            
            string categoryName = eventForAdding.Category;
            string description = eventForAdding.Description;
            var addEvent = userAdminPage.AddEventClick();
            SetRequredFields(photoPath, title, description, categoryName,addEvent);
            Assert.That(addEvent.IsPresentAddedPhoto, Is.True);
            //Assert.That(addEvent.IsNotFilledMapPosition, Is.True);
            addEvent.ChooseMapPosition();
            Assert.That(addEvent.IsNotFilledMapPosition, Is.False);
            addEvent.Save();
            
            Assert.That(addEvent.IsEventCreated, Is.True);
            Assert.That(Default(addEvent), Is.False);            
        }
        [TestCaseSource(typeof(AddRequiredEvent))]
        public void AddOnlineEvent(Event eventForAdding, string photoPath)
        {

            string title = eventForAdding.Title;            
            string onlinePath = eventForAdding.OnlinePath;            
            string categoryName = eventForAdding.Category;
            string description = eventForAdding.Description;

            var addEvent = userAdminPage.AddEventClick();
            SetRequredFields(photoPath, title, description, categoryName, addEvent);

            //Assert.That(addEvent.IsNotFilledMapPosition, Is.True);
            addEvent.SetOnlineEvent();
            //Assert.That(addEvent.IsNotFilledOnlinePosition, Is.True);
            addEvent.SetOnlinePath(onlinePath);
            Assert.That(addEvent.IsNotFilledOnlinePosition, Is.False);
            addEvent.Save();
            Assert.That(addEvent.IsEventCreated, Is.True);
            Assert.That(Default(addEvent), Is.False);

        }
        [Test]
        public void ImpossibilityCreateEvent()
        {            
            var home = GetHomeObject();
            Assert.That(home.IsHomeObject, Is.True);            
        }

        [TestCaseSource(typeof(AddRequiredEvent))]
        [Obsolete]
        public void SetPublicEvent(Event eventForAdding, string photoPath)
        {

            string title = eventForAdding.Title;
            string onlinePath = eventForAdding.OnlinePath;
            string categoryName = eventForAdding.Category;
            string description = eventForAdding.Description;
            Assert.That(userAdminPage.GetCountElementSideBar(), Is.EqualTo(8));
            Console.WriteLine(userAdminPage.GetCountElementSideBar());
            var addEvent = userAdminPage.AddEventClick();
            SetRequredFields(photoPath, title, description, categoryName, addEvent);

            addEvent.ChooseMapPosition();
           
            addEvent.SetPublicEvent();
            addEvent.Save();
            Assert.That(addEvent.IsEventCreated, Is.True);
            Assert.That(Default(addEvent), Is.False);

        }

        
        [TestCaseSource(typeof(AddRequiredEvent))]
        public void AddDayEvent(Event eventForAdding, string photoPath)
        {
            string title = eventForAdding.Title;
            string onlinePath = eventForAdding.OnlinePath;
            string categoryName = eventForAdding.Category;
            string description = eventForAdding.Description;
            string frequency = eventForAdding.Frequency;
            int daysFrom = eventForAdding.DaysFrom;
            int daysTo = eventForAdding.DaysTo;
            int eventPrevCount;
            int eventEndCound;
            userAdminPage.Refresh();

            userAdminPage.HomeBtnClick();

            userAdminPage.MoveDown();
            eventPrevCount = GetPrevEvent(homeEvent);
            Console.WriteLine(eventPrevCount);

            var addEvent = userAdminPage.AddEventClick();
            SetRequredFields(photoPath, title, description, categoryName, addEvent);

            //Assert.That(addEvent.IsChoosenMapPosition, Is.False);
            var res = addEvent.ChooseMapPosition();
            //Assert.That(addEvent.IsChoosenMapPosition, Is.True);
            Assert.That(res.IsPeriodicityVisible, Is.False);
            Assert.That(res.IsFrequencyVisible, Is.False);
            addEvent.SetReccurentEvent();
            Assert.That(addEvent.IsPeriodicityVisible, Is.True);
            Assert.That(addEvent.IsFrequencyVisible, Is.True);
            addEvent.ChooseDailyOption();
            addEvent.SetFrequency(frequency);
            addEvent.SetDateFrom(daysFrom);
            addEvent.Save();
            Assert.That(addEvent.IsEventCreated, Is.True);
            userAdminPage.HomeBtnClick();
            userAdminPage.MoveDown();
            eventEndCound = homeEvent.GetEventcountOnLastPage();
            Assert.That(eventPrevCount, Is.EqualTo(eventEndCound - 1));


        }
        [TestCaseSource(typeof(AddRequiredEvent))]
        public void AddWeekEvent(Event eventForAdding, string photoPath)
        {
            string title = eventForAdding.Title;
            string onlinePath = eventForAdding.OnlinePath;
            string categoryName = eventForAdding.Category;
            string description = eventForAdding.Description;
            string frequency = eventForAdding.Frequency;
            int daysFrom = eventForAdding.DaysFrom;
            int daysTo = eventForAdding.DaysTo;
            int eventPrevCount;
            int eventEndCound;
            userAdminPage.Refresh();

            userAdminPage.HomeBtnClick();
            userAdminPage.MoveDown();
            eventPrevCount = GetPrevEvent(homeEvent);

            var addEvent = userAdminPage.AddEventClick();
            SetRequredFields(photoPath, title, description, categoryName, addEvent);

            //Assert.That(addEvent.IsChoosenMapPosition, Is.False);
            var res = addEvent.ChooseMapPosition();
            //Assert.That(addEvent.IsChoosenMapPosition, Is.True);
            Assert.That(res.IsPeriodicityVisible, Is.False);
            Assert.That(res.IsFrequencyVisible, Is.False);
            addEvent.SetReccurentEvent();
            Assert.That(addEvent.IsPeriodicityVisible, Is.True);
            Assert.That(addEvent.IsFrequencyVisible, Is.True);
            addEvent.ChooseWeeklyOption();
            addEvent.SetFrequency(frequency);
            addEvent.SetDateFrom(daysFrom);
            addEvent.SetDateTo(daysTo);
            addEvent.Save();
            Assert.That(addEvent.IsEventCreated, Is.True);
            userAdminPage.HomeBtnClick();
            userAdminPage.MoveDown();
            eventEndCound = homeEvent.GetEventcountOnLastPage();
            Assert.That(eventPrevCount, Is.EqualTo(eventEndCound - 1));
        }
        [TestCaseSource(typeof(AddRequiredEvent))]
        public void AddMonthEvent(Event eventForAdding, string photoPath)
        {
            string title = eventForAdding.Title;
            string onlinePath = eventForAdding.OnlinePath;
            string categoryName = eventForAdding.Category;
            string description = eventForAdding.Description;
            string frequency = eventForAdding.Frequency;
            int daysFrom = eventForAdding.DaysFrom;
            int daysTo = eventForAdding.DaysTo;
            int eventPrevCount;
            int eventEndCound;
            userAdminPage.Refresh();

            userAdminPage.HomeBtnClick();
            userAdminPage.MoveDown();
            eventPrevCount = GetPrevEvent(homeEvent);

            var addEvent = userAdminPage.AddEventClick();
            SetRequredFields(photoPath, title, description, categoryName, addEvent);

            //Assert.That(addEvent.IsChoosenMapPosition, Is.False);
            var res = addEvent.ChooseMapPosition();
            //Assert.That(addEvent.IsChoosenMapPosition, Is.True);
            Assert.That(res.IsPeriodicityVisible, Is.False);
            Assert.That(res.IsFrequencyVisible, Is.False);
            addEvent.SetReccurentEvent();
            Assert.That(addEvent.IsPeriodicityVisible, Is.True);
            Assert.That(addEvent.IsFrequencyVisible, Is.True);
            addEvent.ChooseMonthlyOption();
            addEvent.SetFrequency(frequency);
            addEvent.SetDateFrom(daysFrom);
            addEvent.SetDateTo(daysTo);
            addEvent.Save();
            Assert.That(addEvent.IsEventCreated, Is.True);
            userAdminPage.HomeBtnClick();
            userAdminPage.MoveDown();
            eventEndCound = homeEvent.GetEventcountOnLastPage();
            Assert.That(eventPrevCount, Is.EqualTo(eventEndCound - 1));


        }
        [TestCaseSource(typeof(AddRequiredEvent))]
        public void AddYearlyEvent(Event eventForAdding, string photoPath)
        {

            string title = eventForAdding.Title;
            string onlinePath = eventForAdding.OnlinePath;
            string categoryName = eventForAdding.Category;
            string description = eventForAdding.Description;
            string frequency = eventForAdding.Frequency;
            int daysFrom = eventForAdding.DaysFrom;
            int daysTo = eventForAdding.DaysTo;
            int eventPrevCount;
            int eventEndCound;
            userAdminPage.Refresh();

            userAdminPage.HomeBtnClick();
            userAdminPage.MoveDown();
            eventPrevCount = GetPrevEvent(homeEvent);

            var addEvent = userAdminPage.AddEventClick();
            SetRequredFields(photoPath, title, description, categoryName, addEvent);

            //Assert.That(addEvent.IsChoosenMapPosition, Is.False);
            var res = addEvent.ChooseMapPosition();
            //Assert.That(addEvent.IsChoosenMapPosition, Is.True);
            Assert.That(res.IsPeriodicityVisible, Is.False);
            Assert.That(res.IsFrequencyVisible, Is.False);
            addEvent.SetReccurentEvent();
            Assert.That(addEvent.IsPeriodicityVisible, Is.True);
            Assert.That(addEvent.IsFrequencyVisible, Is.True);
            addEvent.ChooseYearlyOption();
            addEvent.SetFrequency(frequency);
            addEvent.SetDateFrom(daysFrom);
            addEvent.SetDateTo(daysTo);
            addEvent.Save();
            Assert.That(addEvent.IsEventCreated, Is.True);
            userAdminPage.HomeBtnClick();
            userAdminPage.MoveDown();
            eventEndCound = homeEvent.GetEventcountOnLastPage();
            Assert.That(eventPrevCount, Is.EqualTo(eventEndCound - 1));
        }
        

        [TearDown]
        public override void TearDown()
        {
            base.TearDown();
        }

        [TestCaseSource(typeof(AddRequiredEvent))]
        [Obsolete]
        public void Test(Event eventForAdding, string photoPath)
        {
            string title = eventForAdding.Title;
            string onlinePath = eventForAdding.OnlinePath;
            string categoryName = eventForAdding.Category;
            string description = eventForAdding.Description;
            string frequency = eventForAdding.Frequency;
            int daysFrom = eventForAdding.DaysFrom;
            int daysTo = eventForAdding.DaysTo;
            int eventPrevCount;
            int eventEndCound;
            userAdminPage.Refresh();
           
            userAdminPage.HomeBtnClick();
            //Thread.Sleep(BaseConfigData.ThreadSleep);

            userAdminPage.MoveDown();
            eventPrevCount = GetPrevEvent(homeEvent);
            Console.WriteLine(eventPrevCount);

            var addEvent = userAdminPage.AddEventClick();
            SetRequredFields(photoPath, title, description, categoryName, addEvent);

            //Assert.That(addEvent.IsChoosenMapPosition, Is.False);
            var res=addEvent.ChooseMapPosition();
            //Assert.That(addEvent.IsChoosenMapPosition, Is.True);
            Assert.That(res.IsPeriodicityVisible, Is.False);
            Assert.That(res.IsFrequencyVisible, Is.False);
            addEvent.SetReccurentEvent();
            Assert.That(addEvent.IsPeriodicityVisible, Is.True);
            Assert.That(addEvent.IsFrequencyVisible, Is.True);
            addEvent.ChooseWeeklyOption();
            addEvent.SetFrequency(frequency);
            addEvent.SetDateFrom(daysFrom);
            addEvent.SetDateTo(daysTo);
            addEvent.Save();
            Assert.That(addEvent.IsEventCreated, Is.True);
            userAdminPage.HomeBtnClick();
            userAdminPage.MoveDown();
            eventEndCound = homeEvent.GetEventcountOnLastPage();
            Console.WriteLine(eventEndCound);
            Assert.That(eventPrevCount, Is.EqualTo(eventEndCound - 1));
        }
    }
}
