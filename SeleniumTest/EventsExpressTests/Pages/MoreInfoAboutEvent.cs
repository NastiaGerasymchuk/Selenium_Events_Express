using OpenQA.Selenium;
using SeleniumTest.EventsExpressTests.Pages;
using System;

namespace SeleniumTest.EventsExpressTests.Models
{
    public class MoreInfoAboutEvent:BaseClass
    {
        private string cssPhotoPath = "#main > div > div > div.col-9 > div.col-12 > img";
        private string cssTitle = "#main > div > div > div.col-9 > div.col-12 > div.text-block > span.title";
        private string cssProtection = "#main > div > div > div.col-9 > div.col-12 > div.text-block > span:nth-child(3)";
        private string cssParticipants = "#main > div > div > div.col-9 > div.col-12 > div.text-block > span.maxParticipants";
        private string cssFullDate = "#main > div > div > div.col-9 > div.col-12 > div.text-block > span:nth-child(7)";
        private string cssOnline = "#main > div > div > div.col-9 > div.col-12 > div.text-block > div > a";
        private string cssCategory = "#main > div > div > div.col-9 > div.col-12 > div.text-block > span:nth-child(10)";
        private string cssDescription = "#main > div > div > div.col-9 > div.text-box-big.overflow-auto.shadow.p-3.mb-5.mt-2.bg-white.rounded";
        private string cssEdit = "#main > div > div > div.col-9 > div.col-12 > div.button-block > button:nth-child(1)";
        private By photo;
        private By title;
        private By protection;
        private By participants;
        private By fullDate;
        private By online;
        private By category;
        private By description;
        private By btnEdit;
        [Obsolete]
        public MoreInfoAboutEvent(IWebDriver driver):base(driver)
        {
            photo=Css(cssPhotoPath);
            title = Css(cssTitle);
            protection = Css(cssProtection);
            participants = Css(cssParticipants);
            fullDate = Css(cssFullDate);
            online = Css(cssOnline);
            category = Css(cssCategory);
            description = Css(cssDescription);
            btnEdit = Css(cssEdit);
        }
        public string EditText()
        {
            return Text(btnEdit);
        }
       
        public string GetHref()
        {
            return GetAttribute(online, "href");
        }
        public string GetTitle()
        {
            return Text(title);
        }
        public string GetProtection()
        {
            return Text(protection);
        }
        public string GetParticipants()
        {
            return Text(participants);
        }
        public string GetFullDate()
        {
            return Text(fullDate);
        }
        public string GetOnlineText()
        {
            return Text(online);
        }
        public string GetCategory()
        {
            return Text(category);
        }
        public string GetDescription()
        {
            return Text(description);
        }
       
        public bool IsVisiblePhoto()
        {
           return GetVisible(photo);
        }
        

    }
}
