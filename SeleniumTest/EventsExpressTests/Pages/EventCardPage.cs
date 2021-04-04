using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumTest.EventsExpressTests.Models;
using SeleniumTest.EventsExpressTests.Pages;
using System;

namespace SeleniumTest.EventsExpressTests
{
    class EventCardPage:BaseClass
    {
        int eventOrder;
        private string byParentSelector;
        private string cssTitle = "> div > div.MuiCardHeader-root > div.MuiCardHeader-content > span.MuiTypography-root.MuiCardHeader-title.title.MuiTypography-body2.MuiTypography-displayBlock";
        private string cssBtnAuthor = " > div > div.MuiCardHeader-root > div.MuiCardHeader-avatar > button";
        private string cssAuthor= "> div > div.MuiCardHeader-root > div.MuiCardHeader-avatar > button > span.MuiButton-label > span > div > div";
        private string cssDate = " > div > div.MuiCardHeader-root > div.MuiCardHeader-content > span.MuiTypography-root.MuiCardHeader-subheader.MuiTypography-body2.MuiTypography-colorTextSecondary.MuiTypography-displayBlock > time";
        private string cssVisitors = " > div > div.MuiCardHeader-root > div.MuiCardHeader-action > button > span.MuiIconButton-label > span > span";
        private string cssBtnVisitors = " > div > div.MuiCardHeader-root > div.MuiCardHeader-action > button";
        private string cssPhoto = " > div > div.MuiCardMedia-root > a > img";
        private string cssdivPhoto = " > div > div.MuiCardMedia-root";
        private string cssParticipantsCount = " > div > div:nth-child(3) > p";
        private string cssDescription = " > div > div:nth-child(4) > p";
        private string cssOnlinePath = " > div > div.MuiCardActions-root > div > div:nth-child(1) > a";
        private string cssCategory = " > div > div.MuiCardActions-root > div > div.float-left > div";
        private string cssEyeBtn = " > div > div.MuiCardActions-root > div > div.d-flex.flex-row.align-items-center.justify-content-center.float-right > a > button";
        private string cssCustomMenu = " > div > div.MuiCardActions-root > div > div.d-flex.flex-row.align-items-center.justify-content-center.float-right > div > button";
        private string cssLock = " > div > div.MuiCardActions-root > div > div.d-flex.flex-row.align-items-center.justify-content-center.float-right > div:nth-child(2)";
       
        private By headerAuthor;
        private By headerBtnAuthor;
        private By headerTitle;
        private By headerDate;
        private By headerVisitors;
        private By headerVisitorsBtn;
        private By photo;
        private By divPhoto;
        private By participantsCount;
        private By description;
        private By onlinePath;
        private By category;
        private By eyeBtn;
        private By socialSharingBtn;
        private By lockBtn;
        [Obsolete]

        public EventCardPage(IWebDriver driver,string parentSelector,int eventOrder):base(driver)
        {
            this.eventOrder = eventOrder;
            byParentSelector = parentSelector;
            headerAuthor = Css(parentSelector+cssAuthor);
            headerBtnAuthor = Css(parentSelector + cssBtnAuthor);
            headerTitle = Css(parentSelector + cssTitle);
            headerDate = Css(parentSelector + cssDate);
            headerVisitors = Css(parentSelector+cssVisitors);
            headerVisitorsBtn = Css(parentSelector+cssBtnVisitors);
            photo = Css(parentSelector + cssPhoto);
            divPhoto = Css(parentSelector + cssdivPhoto);
            participantsCount = Css(parentSelector + cssParticipantsCount);
            description = Css(parentSelector + cssDescription);
            onlinePath = Css(parentSelector + cssOnlinePath);
            category = Css(parentSelector + cssCategory);
            eyeBtn = Css(parentSelector + cssEyeBtn);
            socialSharingBtn = Css(parentSelector + cssCustomMenu);
            //socialSharingBtn = By.XPath("/ html / body / div[1] / div[3] / div[2] / div / div[1] / div / div[5] / div / div[3] / div[2] / button");
            lockBtn = Css(parentSelector + cssLock);
            //lockBtn = By.XPath("/html/body/div[1]/div[3]/div[2]/div/div[1]/div/div[5]/div/div[3]/div[1]/button");
            
        }
        public void BtnLockClick()
        {
            Click(lockBtn);
        }
        [Obsolete]
        public string GetHeaderAuthor()
        {
            return Text(headerAuthor);
        }
        private void Hover(By by)
        {
            var element = wait.Until(ExpectedConditions.ElementIsVisible(by));
            Actions action = new Actions(driver);
            action.MoveToElement(element).Perform();
            //Waiting for the menu to be displayed    
            System.Threading.Thread.Sleep(4000);

        }
        public void HeaderAuthorBtnHover()
        {

            Hover(headerBtnAuthor);
        }
        public AuthorInfo HeaderAuthorBtnClick()
        {

            Click(headerBtnAuthor);
            int authorOrder = eventOrder;//order of Author is on 2 more than order info about author
            return new AuthorInfo(driver,authorOrder);
        }
        
        public string GetAuthorBtnTitle()
        {
           return GetTitle(headerBtnAuthor);
        }
        [Obsolete]
        public string GetHeaderTitle()
        {
            return Text(headerTitle);
        }
        [Obsolete]
        public string GetHeaderDate()
        {
            return Text(headerDate);
        }
        public string GetHeaderVisitors()
        {
            return Text(headerVisitors);
        }
        public EventCardPage HeaderVisitorsBtnClick()
        {
            Click(headerVisitorsBtn);
            return this;
        }
        public MoreInfoAboutEvent PhotoClick()
        {
            Click(photo);
            return new MoreInfoAboutEvent(driver);
        }
        public bool IsPhotoVisible()
        {
            return GetVisible(photo);
        }
        public string GetPhotoTitle()
        {
           return GetTitle(divPhoto);
        }
        public MoreInfoAboutEvent EyeClick()
        {
            Click(eyeBtn);
            return new MoreInfoAboutEvent(driver);
        }
        public SocialSharing SocialSharingClick()
        {
            Click(socialSharingBtn);
            return new SocialSharing(driver,eventOrder);
        }
        public string GetParticipants()
        {
            return Text(participantsCount);
        }
        public string GetDescription()
        {
            return Text(description);
        }
        public string GetOnlineName()
        {
            return Text(onlinePath);
        }
        public string GetOnlinePath()
        {
            return wait.Until(ExpectedConditions.ElementIsVisible(onlinePath)).GetAttribute("href");
        }
        public string GetCategory()
        {
            return Text(category);
        }
        public bool IsVisibleBtnEye()
        {
            return GetVisible(eyeBtn);
        }
        public bool IsVisibleBtnSocialSharig()
        {
            return GetVisible(socialSharingBtn);
        }
        private bool GetVisible(By by)
        {
            try
            {
                //wait.Until(ExpectedConditions.ElementIsVisible(by));
                IWebElement webElement = driver.FindElement(by);

                return webElement.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
       

    }
}
