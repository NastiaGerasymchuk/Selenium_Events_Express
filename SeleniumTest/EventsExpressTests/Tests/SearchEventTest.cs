using NUnit.Framework;
using SeleniumTest.EventsExpressTests.Data;
using SeleniumTest.EventsExpressTests.Data.Events;
using SeleniumTest.EventsExpressTests.Models;
using SeleniumTest.EventsExpressTests.Tests;
using System;
using System.Globalization;


namespace SeleniumTest.EventsExpressTests
{
    [TestFixture]
    public class SearchEventTest:BaseTest
    {
        
        private string stringDateFormat = @"MM\/dd\/yyyy";
        private string fromValueText = "From";
        private string toValueText = "To";
        private string selectCategoryValue = "Sea";
        private const int StartEventCount = 3;
        private const int SharingCount = 4;
        private const string Participants = "Participants";
        private const string EventText = "event";
        private const int MonthEventCount = 1;
        private string cartPathBegin = "#main > div.events-container > div > div:nth-child(";
        private string cartPathEnd = ")";




        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
        }
        
        [Test]
        [Obsolete]
        public void LoadPage_BtnSearchBtnReset_EnabledFalseBeOnCurrentPage()
        {

            HomeEvent homeEvent = GetHomeObject();
            Assert.That(homeEvent.GetEnabledBtnSearchState(), Is.False);
            var resetClick = homeEvent.ResetClick();
            Assert.That(resetClick.GetType() == typeof(HomeEvent), Is.True);
            Assert.That(homeEvent.GetEnabledBtnSearchState(), Is.False);
        }
        [Test]
        [Obsolete]
        public void LoadPage_KeyWordBtnSearchBtnReset()
        {
            HomeEvent homeEvent = GetHomeObject();
            var textKeyWord = homeEvent.GetInputKeyWord();
            Assert.That(homeEvent.GetEnabledBtnSearchState(), Is.False);
            Assert.That(textKeyWord, Is.Empty);
            Assert.That(homeEvent.DefaultState(), Is.False);

            homeEvent.SetInputKeyword("set value");
            textKeyWord = homeEvent.GetInputKeyWord();
            Assert.That(textKeyWord.Length, Is.AtLeast(1));
            Assert.That(homeEvent.EnabledSearch(), Is.True);

            Assert.That(homeEvent.GetEnabledBtnSearchState(), Is.False);

            homeEvent.ResetClick();
            textKeyWord = homeEvent.GetInputKeyWord();
            Assert.That(homeEvent.GetEnabledBtnSearchState(), Is.False);
            Assert.That(textKeyWord, Is.Empty);
            Assert.That(homeEvent.DefaultState(), Is.False);

        }
        [Test]
        [Obsolete]
        public void Screen()
        {
            HomeEvent homeEvent = GetHomeObject();
            var textKeyWord = homeEvent.GetInputKeyWord();
            Assert.That(homeEvent.GetEnabledBtnSearchState(), Is.False);
            Assert.That(textKeyWord, Is.Empty);
            Assert.That(homeEvent.DefaultState(), Is.False);

            homeEvent.SetInputKeyword("set value");
            textKeyWord = homeEvent.GetInputKeyWord();
            Assert.That(textKeyWord.Length, Is.AtLeast(1));
            Assert.That(homeEvent.EnabledSearch(), Is.True);

            Assert.That(homeEvent.GetEnabledBtnSearchState(), Is.False);

            textKeyWord = homeEvent.GetInputKeyWord();
            
        }
        [Test]
        [Obsolete]
        public void LoadPage_KeyWordUnfoldedFilter()
        {
            HomeEvent homeEvent = GetHomeObject();
            var textKeyWord = homeEvent.GetInputKeyWord();
            Assert.That(homeEvent.GetEnabledBtnSearchState(), Is.False);
            Assert.That(textKeyWord, Is.Empty);
            Assert.That(homeEvent.DefaultState(), Is.False);

            homeEvent.SetInputKeyword("set value");
            textKeyWord = homeEvent.GetInputKeyWord();
            Assert.That(textKeyWord.Length, Is.AtLeast(1));
            Assert.That(homeEvent.EnabledSearch(), Is.True);

            Assert.That(homeEvent.GetEnabledBtnSearchState(), Is.False);

            homeEvent.BtnMoreClick();
            Assert.That(homeEvent.DefaultState(), Is.True);

            homeEvent.BtnLessClick();
            Assert.That(homeEvent.DefaultState(), Is.False);

            homeEvent.ResetClick();
            textKeyWord = homeEvent.GetInputKeyWord();
            Assert.That(homeEvent.GetEnabledBtnSearchState(), Is.False);
            Assert.That(textKeyWord, Is.Empty);
            Assert.That(homeEvent.DefaultState(), Is.False);
        }
        [Test]
        [Obsolete]
        public void LoadPage_Date_Category_Select_FilterUnfoldedFilter()
        {
           
            HomeEvent homeEvent = GetHomeObject();
            homeEvent.BtnMoreClick();
            homeEvent.SetSelect(selectCategoryValue);
            var categoryValue = homeEvent.GetSelectElementSettingValue();
            Assert.That(selectCategoryValue, Is.EqualTo(categoryValue));
        }
        [Test]
        [Obsolete]
        public void DefaultStateUnfoldedFilter()
        {           
            HomeEvent homeEvent = GetHomeObject();
            Assert.That(homeEvent.GetEnabledBtnSearchState(), Is.False);
            Assert.That(homeEvent.DefaultState(), Is.False);

            homeEvent.BtnMoreClick();
            var today = DateTime.Now;
            var stringToday = today.ToString("d", DateTimeFormatInfo.InvariantInfo);
            var startDateFrom = homeEvent.GetDateFrom();
            var startDateTo = homeEvent.GetDateTo();
            var startCategory = homeEvent.GetSelectElement();
            Assert.That(startDateFrom, Is.EqualTo(stringToday));
            Assert.That(startDateTo, Is.EqualTo(stringToday));
            Assert.That(startCategory, Is.Empty);
            Assert.That(homeEvent.DefaultState(), Is.True);
        }

        [Test]
        [Obsolete]
        public void LoadPage_Btn_ResetWithoutAddData_FilterUnfoldedFilter()
        {
            var today = DateTime.Now;
            HomeEvent homeEvent = GetHomeObject();
            homeEvent.BtnMoreClick();

            homeEvent.ResetClick();
            var stringToday = today.ToString("d", DateTimeFormatInfo.InvariantInfo);
            var startDateFrom = homeEvent.GetDateFrom();
            var startDateTo = homeEvent.GetDateTo();
            var startCategory = homeEvent.GetSelectElement();
            Assert.That(startDateFrom, Is.EqualTo(stringToday));
            Assert.That(startDateTo, Is.EqualTo(stringToday));
            Assert.That(startCategory, Is.Empty);
            Assert.That(homeEvent.DefaultState(), Is.True);
        }
        [Test]
        [Obsolete]
        public void GetEventCountFromLoadPage()
        {
          
            HomeEvent homeEvent = GetHomeObject();
            Assert.That(homeEvent.GetEventsCount, Is.EqualTo(StartEventCount));
        }
        [Test]
        [Obsolete]
        [TestCaseSource(typeof(Events))]
        public void AuthorDetails(Event myEvent, int eventOrder)
        {
            string author = myEvent.Author.Substring(0, 1);
            string card = $"{cartPathBegin}{eventOrder}{cartPathEnd}";
            HomeEvent homeEvent = GetHomeObject();
            
            EventCardPage eventCardPage = new EventCardPage(driver, card,eventOrder);

            Assert.That(eventCardPage.GetHeaderAuthor, Is.EqualTo(author));
            eventCardPage.HeaderAuthorBtnHover();
            Assert.That(eventCardPage.GetAuthorBtnTitle, Is.EqualTo(myEvent.Author));

            var resAuthorInfo=eventCardPage.HeaderAuthorBtnClick();
            Assert.That(resAuthorInfo.GetType() == typeof(AuthorInfo), Is.True);
            
            string res = resAuthorInfo.GetAuthorTitle();
            Assert.That(resAuthorInfo.GetAuthorTitle, Is.EqualTo(myEvent.Author));

            var resHome=resAuthorInfo.AuthorClick();
            //eventCardPage.Tab();
            Assert.That(resHome.GetType() == typeof(HomeEvent), Is.True);
            
        }
        [Test]
        [Obsolete]
        [TestCaseSource(typeof(Events))]
        public void PhotoDetails(Event myEvent, int eventOrder)
        {
            string protectionText= $"{myEvent.Protection.ToString("g")} {EventText}";
            string participants = $"{ myEvent.Participants}{Participants}";
            string card = $"{cartPathBegin}{eventOrder}{cartPathEnd}";
            HomeEvent homeEvent = GetHomeObject();
            EventCardPage eventCardPage = new EventCardPage(driver, card, eventOrder);
            Assert.That(eventCardPage.IsPhotoVisible, Is.True);
            Assert.That(eventCardPage.GetPhotoTitle, Is.EqualTo(myEvent.Title));

            var resPhotoClick= eventCardPage.PhotoClick();
            Assert.That(resPhotoClick.GetType() == typeof(MoreInfoAboutEvent), Is.True);
            Assert.That(resPhotoClick.IsVisiblePhoto(), Is.True);
            Assert.That(resPhotoClick.GetTitle(), Is.EqualTo(myEvent.Title));
            Assert.That(resPhotoClick.GetProtection, Is.EqualTo(protectionText));
            Assert.That(resPhotoClick.GetParticipants, Is.EqualTo(participants));
            Assert.That(resPhotoClick.GetFullDate, Is.EqualTo(myEvent.FullDate));
            Assert.That(resPhotoClick.GetOnlineText, Is.EqualTo(myEvent.OnlineTitle));
            Assert.That(resPhotoClick.GetHref, Is.EqualTo(myEvent.OnlinePath));
            Assert.That(resPhotoClick.GetCategory, Is.EqualTo(myEvent.Category));
            Assert.That(resPhotoClick.GetDescription, Is.EqualTo(myEvent.Description));
            eventCardPage.GoToBeginPage();

        }
        [Obsolete]
        [TestCase("admin@gmail.com","1qaz1qaz",1)]
        public void EventDetailsByClickingLock(string email,string password,int eventOrder)
        {
            string card = $"{cartPathBegin}{eventOrder}{cartPathEnd}";
            HomeEvent home = GetHomeObject();
            var registerPage = home.Registration();
            Assert.That(registerPage.GetType() == typeof(RegisterPage), Is.True);

            registerPage.SetEmail(email);
            registerPage.SetPassword(password);
            registerPage.LoginBtnClickValidData();
            EventCardPage eventCardPage = new EventCardPage(driver, card, eventOrder);

            eventCardPage.SocialSharingClick();
        }

        [Obsolete]
        [TestCaseSource(typeof(Events))]
        public void EventDetailsByClickingEye(Event myEvent, int eventOrder)
        {
            string author = myEvent.Author.Substring(0, 1);
            string protectionText = $"{myEvent.Protection.ToString("g")} {EventText}";
            string participants = $"{ myEvent.Participants}{Participants}";
            string card = $"{cartPathBegin}{eventOrder}{cartPathEnd}";
            HomeEvent homeEvent = GetHomeObject();
            EventCardPage eventCardPage = new EventCardPage(driver, card, eventOrder);
            Assert.That(eventCardPage.IsVisibleBtnEye, Is.True);
            var resEyeClick = eventCardPage.EyeClick();
            Assert.That(resEyeClick.GetType() == typeof(MoreInfoAboutEvent), Is.True);

            Assert.That(resEyeClick.IsVisiblePhoto(), Is.True);
            Assert.That(resEyeClick.GetTitle(), Is.EqualTo(myEvent.Title));
            Assert.That(resEyeClick.GetProtection, Is.EqualTo(protectionText));
            Assert.That(resEyeClick.GetParticipants, Is.EqualTo(participants));
            Assert.That(resEyeClick.GetFullDate, Is.EqualTo(myEvent.FullDate));
            Assert.That(resEyeClick.GetOnlineText, Is.EqualTo(myEvent.OnlineTitle));
            Assert.That(resEyeClick.GetHref, Is.EqualTo(myEvent.OnlinePath));
            Assert.That(resEyeClick.GetCategory, Is.EqualTo(myEvent.Category));
            Assert.That(resEyeClick.GetDescription, Is.EqualTo(myEvent.Description));

            eventCardPage.GoToBeginPage();

        }
        [Test]
        [Obsolete]
        [TestCaseSource(typeof(Events))]
        public void EventDetails(Event myEvent, int eventOrder)
        {
            string author= myEvent.Author.Substring(0, 1);
            string participants = $"{ myEvent.Participants} {Participants}";
            string card = $"{cartPathBegin}{eventOrder}{cartPathEnd}";

            HomeEvent homeEvent = GetHomeObject();
            EventCardPage eventCardPage = new EventCardPage(driver, card,eventOrder);
            Assert.That(eventCardPage.GetHeaderAuthor, Is.EqualTo(author));
            Assert.That(eventCardPage.GetHeaderTitle, Is.EqualTo(myEvent.Title));
           
            Assert.That(eventCardPage.GetHeaderDate, Is.EqualTo(myEvent.DateFrom));
            Assert.That(eventCardPage.GetHeaderVisitors, Is.EqualTo(myEvent.HeaderVisitor));

            Assert.That(eventCardPage.IsPhotoVisible, Is.True);
            Assert.That(eventCardPage.GetPhotoTitle, Is.EqualTo(myEvent.Title));

            Assert.That(eventCardPage.GetParticipants, Is.EqualTo(participants));

            Assert.That(eventCardPage.GetDescription, Is.EqualTo(myEvent.Description));

            Assert.That(eventCardPage.GetOnlineName, Is.EqualTo(myEvent.OnlineTitle));
            Assert.That(eventCardPage.GetOnlinePath, Is.EqualTo(myEvent.OnlinePath));

            Assert.That(eventCardPage.GetCategory, Is.EqualTo(myEvent.Category));

            Assert.That(eventCardPage.IsVisibleBtnEye, Is.True);
            var resEyeClick = eventCardPage.EyeClick();
            Assert.That(resEyeClick.GetType() == typeof(MoreInfoAboutEvent), Is.True);
            Assert.That(resEyeClick.IsVisiblePhoto(), Is.True);

            var resBeginPage = eventCardPage.GoToBeginPage();

            var resSocialSharingClick = eventCardPage.SocialSharingClick();
            Assert.That(resSocialSharingClick.GetType() == typeof(SocialSharing), Is.True);
            Assert.That(resSocialSharingClick.GetSharingCount(), Is.EqualTo(SharingCount));

            eventCardPage.Esc();
        }
        [Test]
        [Obsolete]
        [TestCaseSource(typeof(EventsFilterKeyword))]
        public void CountEventsByInputKeyword(string filter, int eventCount)
        {
            
            HomeEvent homeEvent = GetHomeObject();
            homeEvent.SetInputKeyword(filter);
            homeEvent.SearchClick();
            Assert.That(homeEvent.GetEventsCount, Is.EqualTo(eventCount));
        }
        [Test]
        [Obsolete]
        [TestCaseSource(typeof(EventsFilterCategory))]
        public void CountEventsByCategorySelect(string filter, int eventCount)
        {
            HomeEvent homeEvent = GetHomeObject();
            homeEvent.BtnMoreClick();

            homeEvent.SetSelect(filter);
            homeEvent.SearchClick();
            Assert.That(homeEvent.GetEventsCount, Is.EqualTo(eventCount));
        }
        [Test]
        [Obsolete]
        [TestCaseSource(typeof(EventsFilterDay))]
        public void CountEventsByDate(int dateFrom,int dateTo, int eventCount)
        {
            HomeEvent homeEvent = GetHomeObject();
            homeEvent.BtnMoreClick();

            homeEvent.SetDateFrom(dateFrom);
            homeEvent.SetDateTo(dateTo);
            homeEvent.SearchClick();
            Assert.That(homeEvent.GetEventsCount, Is.EqualTo(eventCount));
        }
        [Test]
        [Obsolete]
        public void CountEventsByNextMonth()
        {
            HomeEvent homeEvent = GetHomeObject();
            homeEvent.BtnMoreClick();

            homeEvent.SetNextMonthDateFrom();
            homeEvent.SearchClick();
            Assert.That(homeEvent.GetEventsCount, Is.EqualTo(MonthEventCount));
        }

        [Test]
        [Obsolete]
        public void LoadPage_ChooseDateFrom_FilterUnfoldedFilter()
        {
            var today = DateTime.Now;
            int dayCountAdd = 8;
            HomeEvent homeEvent = GetHomeObject();
            homeEvent.BtnMoreClick();

            var addingDays = today.AddDays(dayCountAdd).ToString("d", DateTimeFormatInfo.InvariantInfo);
            homeEvent.SetDateFrom(dayCountAdd);
            var dateToValue = homeEvent.GetDateTo();
            var dateFromValue = homeEvent.GetDateFrom();
            Assert.That(dateToValue, Is.EqualTo(addingDays));
            Assert.That(dateFromValue, Is.EqualTo(addingDays));
            Assert.That(homeEvent.GetEnabledBtnSearchAfterClicking(), Is.True);

            homeEvent.SearchClick();
            var addingDaysFrom = today.AddDays(dayCountAdd).ToString("d", DateTimeFormatInfo.InvariantInfo);
            dateFromValue = homeEvent.GetDateFrom();
           
            Assert.That(dateFromValue, Is.EqualTo(addingDaysFrom));
            Assert.That(homeEvent.DefaultState(), Is.True);
            Assert.That(homeEvent.GetEnabledBtnSearchAfterClicking(), Is.False);
        }

        [Test]
        [Obsolete]
        public void LoadPage_ChooseDateTo_FilterUnfoldedFilter()
        {
            var today = DateTime.Now;
            int dayAddDateTo = 3;
            HomeEvent homeEvent = GetHomeObject();
            homeEvent.BtnMoreClick();

            var addingDaysTo = today.AddDays(dayAddDateTo).ToString("d", DateTimeFormatInfo.InvariantInfo);
            homeEvent.SetDateTo(dayAddDateTo);
            var dateToValue = homeEvent.GetDateTo();
            Assert.That(dateToValue, Is.EqualTo(addingDaysTo));

            homeEvent.SearchClick();
           
            addingDaysTo = today.AddDays(dayAddDateTo).ToString("d", DateTimeFormatInfo.InvariantInfo);
            dateToValue = homeEvent.GetDateTo();
            Assert.That(homeEvent.DefaultState(), Is.True);
            Assert.That(dateToValue, Is.EqualTo(addingDaysTo));            
            Assert.That(homeEvent.GetEnabledBtnSearchAfterClicking(), Is.False);
        }
        [Test]
        [Obsolete]
        public void LoadPage_SelectCategory_FilterUnfoldedFilter()
        {
            HomeEvent homeEvent = GetHomeObject();
            homeEvent.BtnMoreClick();

            homeEvent.SetSelect(selectCategoryValue);
            var categoryValue = homeEvent.GetSelectElementSettingValue();
            Assert.That(selectCategoryValue, Is.EqualTo(categoryValue));

            homeEvent.SearchClick();
           
            categoryValue = homeEvent.GetSelectElementSettingValue();           
            Assert.That(homeEvent.DefaultState(), Is.True);
            Assert.That(selectCategoryValue, Is.EqualTo(categoryValue));
            Assert.That(homeEvent.GetEnabledBtnSearchAfterClicking(), Is.False);
        }
        [Test]
        [Obsolete]
        public void LoadPage_BtnFilter_FilterUnfoldedFilter()
        {
            HomeEvent homeEvent = GetHomeObject();
            homeEvent.BtnMoreClick();

            var filterRes = homeEvent.BtnFilterByLocationClick();
            Assert.That(filterRes.GetType() == typeof(FilterByLocation), Is.True);

            var filterBtn = filterRes.ClickFilterBtn();
            Assert.That(filterBtn.GetType() == typeof(HomeEvent), Is.True);
        }
        [Test]
        [Obsolete]
        public void LoadPage_BtnLess_FilterUnfoldedFilter()
        {
            HomeEvent homeEvent = GetHomeObject();
            homeEvent.BtnMoreClick();

            homeEvent.BtnLessClick();
            Assert.That(homeEvent.DefaultState(), Is.False);
        }
        [Test]
        [Obsolete]
        public void LoadPage_Date_Category_FilterUnfoldedFilter()
        {
            var today = DateTime.Now;
            int dayCountAdd = 8;
            int dayAddDateTo = 3;
            HomeEvent homeEvent = GetHomeObject();
            Assert.That(homeEvent.GetEnabledBtnSearchState(), Is.False);
            Assert.That(homeEvent.DefaultState(), Is.False);


            homeEvent.BtnMoreClick();
            var stringToday = today.ToString("d", DateTimeFormatInfo.InvariantInfo);
            var startDateFrom = homeEvent.GetDateFrom();
            var startDateTo = homeEvent.GetDateTo();
            var startCategory = homeEvent.GetSelectElement();
            Assert.That(startDateFrom, Is.EqualTo(stringToday));
            Assert.That(startDateTo, Is.EqualTo(stringToday));
            Assert.That(startCategory, Is.Empty);
            Assert.That(homeEvent.DefaultState(), Is.True);

            homeEvent.ResetClick();
            stringToday = today.ToString("d", DateTimeFormatInfo.InvariantInfo);
            startDateFrom = homeEvent.GetDateFrom();
            startDateTo = homeEvent.GetDateTo();
            startCategory = homeEvent.GetSelectElement();
            Assert.That(startDateFrom, Is.EqualTo(stringToday));
            Assert.That(startDateTo, Is.EqualTo(stringToday));
            Assert.That(startCategory, Is.Empty);
            Assert.That(homeEvent.DefaultState(), Is.True);


            var addingDays = today.AddDays(dayCountAdd).ToString("d", DateTimeFormatInfo.InvariantInfo);
            homeEvent.SetDateFrom(dayCountAdd);
            var dateToValue = homeEvent.GetDateTo();
            var dateFromValue = homeEvent.GetDateFrom();
            Assert.That(dateToValue, Is.EqualTo(addingDays));
            Assert.That(dateFromValue, Is.EqualTo(addingDays));
            Assert.That(homeEvent.GetEnabledBtnSearchAfterClicking(), Is.True);

            var addingDaysTo = today.AddDays(dayAddDateTo + dayCountAdd).ToString("d", DateTimeFormatInfo.InvariantInfo);
            homeEvent.SetDateTo(dayAddDateTo);
            dateToValue = homeEvent.GetDateTo();
            Assert.That(dateToValue, Is.EqualTo(addingDaysTo));

            homeEvent.SetSelect(selectCategoryValue);
            var categoryValue = homeEvent.GetSelectElementSettingValue();
            Assert.That(selectCategoryValue, Is.EqualTo(categoryValue));


            var filterRes = homeEvent.BtnFilterByLocationClick();
            Assert.That(filterRes.GetType() == typeof(FilterByLocation), Is.True);

            var filterBtn = filterRes.ClickFilterBtn();
            Assert.That(filterBtn.GetType() == typeof(HomeEvent), Is.True);

            homeEvent.SearchClick();
            var addingDaysFrom = today.AddDays(dayCountAdd).ToString("d", DateTimeFormatInfo.InvariantInfo);
            dateFromValue = homeEvent.GetDateFrom();
            addingDaysTo = today.AddDays(dayAddDateTo + dayCountAdd).ToString("d", DateTimeFormatInfo.InvariantInfo);
            dateToValue = homeEvent.GetDateTo();
            categoryValue = homeEvent.GetSelectElementSettingValue();
            Assert.That(dateFromValue, Is.EqualTo(addingDaysFrom));
            Assert.That(dateToValue, Is.EqualTo(addingDaysTo));
            Assert.That(homeEvent.DefaultState(), Is.True);
            Assert.That(selectCategoryValue, Is.EqualTo(categoryValue));
            Assert.That(homeEvent.GetEnabledBtnSearchAfterClicking(), Is.False);

            homeEvent.ResetClick();
            stringToday = today.ToString("d", DateTimeFormatInfo.InvariantInfo);
            startDateFrom = homeEvent.GetDateFrom();
            startDateTo = homeEvent.GetDateTo();
            startCategory = homeEvent.GetSelectElement();
            Assert.That(startDateFrom, Is.EqualTo(stringToday));
            Assert.That(startDateTo, Is.EqualTo(stringToday));
            Assert.That(startCategory, Is.Empty);
            Assert.That(homeEvent.DefaultState(), Is.True);

            homeEvent.BtnLessClick();
            Assert.That(homeEvent.DefaultState(), Is.False);

        }
        [Test]
        [Obsolete]
        [TestCaseSource(typeof(InputKeyWordsData))]
        public void InputKeyword_ThisPage(string textData)
        {
            HomeEvent homeEvent = GetHomeObject();
            var res= homeEvent.SetInputKeyword(textData);
            Assert.That(res.GetType()==typeof(HomeEvent),Is.True);
            Assert.That(res.GetInputKeyWord(), Is.EqualTo(textData));
          
        }
        [Test]
        [TestCaseSource(typeof(InputKeyWordsData))]
        [Obsolete]
        public void ResetClick_BeginingSettingValues(string textData)
        {
            HomeEvent homeEvent = GetHomeObject();
            var res = homeEvent.SetInputKeyword(textData);
            homeEvent.ResetClick();
            Assert.That(res.GetInputKeyWord(), Is.EqualTo(""));
        }
        [Test]
        [Obsolete]
        public void LoadPage_BtnSearch_EnabledFalse()
        {
            
            HomeEvent homeEvent = GetHomeObject();
            Assert.That(homeEvent.GetEnabledBtnSearchState(), Is.False);
        }
        [Test]
        [Obsolete]
        [TestCaseSource(typeof(InputKeyWordsData))]
        public void ResetClick_BtnSearch_EnabledFalse(string inputData)
        {
            HomeEvent homeEvent = GetHomeObject();
            var res = homeEvent.SetInputKeyword(inputData);
            homeEvent.ResetClick();
            Assert.That(homeEvent.GetEnabledBtnSearchState(), Is.False);
        }
        [Test]
        [Obsolete]
        public void ClickInputKeys_BtnSearch_EnabledTrue()
        {
            HomeEvent homeEvent = GetHomeObject();
            Assert.That(homeEvent.GetEnabledBtnSearchState(), Is.False);
            homeEvent.ResetClick();
            Assert.That(homeEvent.GetEnabledBtnSearchState(), Is.False);
        }
        [Test]
        [Obsolete]
        [TestCaseSource(typeof(InputKeyWordsData))]
        public void SetInputKeys_BtnSearch_EnabledTrue(string inputData)
        {
            HomeEvent homeEvent = GetHomeObject();
            homeEvent.SetInputKeyword(inputData);
            Assert.That(homeEvent.GetEnabledBtnSearchState(), Is.True);
        }

        [Test]
        [Obsolete]
        public void LoadPage_BtnMoreLessClick_CurrentHomePage8()
        {
            HomeEvent homeEvent = GetHomeObject();

            var res = homeEvent.BtnMoreClick();
            string currentDate = DateTime.Now.ToString(stringDateFormat);
            string resDateFrom = res.GetDateFrom();
            string fromTextvalue = res.GetFromValue();
            string resDateTo = res.GetDateTo();
            string toTextvalue = res.GetToValue();
            res.SetSelect(selectCategoryValue);
            string selectResValue = res.GetSelect();


            Assert.That(res.DefaultState(), Is.True);
            Assert.That(selectResValue, Is.EqualTo(selectCategoryValue));
            Assert.That(fromTextvalue, Is.EqualTo(fromValueText));
            Assert.That(resDateFrom, Is.EqualTo(currentDate));
            Assert.That(toTextvalue, Is.EqualTo(toValueText));
            Assert.That(resDateTo, Is.EqualTo(currentDate));
            Assert.That(res.GetType() == typeof(HomeEvent), Is.True);
        }

        [Obsolete]
        [Test]
        public void BtnLessClic_CurrentHomePage()
        {
            HomeEvent homeEvent = GetHomeObject();
            var resMore = homeEvent.BtnMoreClick();
            var resLess = resMore.BtnLessClick();
            Assert.That(resLess.GetType(), Is.EqualTo(typeof(HomeEvent)));
        }
        [Obsolete]
        [Test]
        public void ExistingData()
        {
            HomeEvent homeEvent = GetHomeObject();
            Assert.That(homeEvent.DefaultState(), Is.False);
        }       
       
        [Test]
        [Obsolete]
        public void BtnLocationClick_FilterByLocation()
        {
            HomeEvent homeEvent = GetHomeObject();
            var resLess=homeEvent.BtnMoreClick();
            var resFilerClick = resLess.BtnFilterByLocationClick();
            Assert.That(resFilerClick.GetType() == typeof(FilterByLocation),Is.True);
        }

        [TearDown]
        public override void TearDown()
        {
            base.TearDown();
        }

    }
}
