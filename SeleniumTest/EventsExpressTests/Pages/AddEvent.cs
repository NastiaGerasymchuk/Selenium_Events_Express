using java.awt;
using java.awt.datatransfer;
using java.awt.@event;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumTest.EventsExpressTests.Data;
using SeleniumTest.EventsExpressTests.Pages;
using System.Text.RegularExpressions;
using System.Threading;

namespace SeleniumTest.EventsExpressTests
{
    public class AddEvent:BaseClass
    {
        private By photoDiv;
        private By btnCrop;
        private By title;
        private By maxParticipants;
        private By inputPublicEvent;
        private By inputRecurentEvent;
        private By online;
        private By onlinePath;
        private By dateFrom;
        private By dateTo;
        private By category;
        private By divCategory;
        private By description;
        private By btnSave;
        private By notEmptyPhoto;
        private By inputMap;
        private By eventType;
        private By listInventories;
        private By mapPosition;
        private By eventCreateNotification;
        private By eventBlock;
        private string cssDivPhoto = "#main > div > form > div.text.text-2.pl-md-4 > div.preview-container.valid > div > div";
        private string cssBtnCrop = "#main > div > form > div.text.text-2.pl-md-4 > div.preview-container.valid > div > div > div > div.controls > button";
        private string cssTitle = "#main > div > form > div.text.text-2.pl-md-4 > div:nth-child(2) > div > div > input";
        private string cssMaxPart = "#main > div > form > div.text.text-2.pl-md-4 > div:nth-child(3) > div > div > input";
        private string xPathPublicEvent = "/html/body/div/div[3]/div/form/div[1]/div[5]/div/label/span[1]/span[1]/input";       
        private string xPathOnline = "/html/body/div/div[3]/div/form/div[1]/div[10]/div/label[2]/span[1]/span[1]/input";
        private string cssOnlinePath = "#main > div > form > div.text.text-2.pl-md-4 > div:nth-child(11) > div > div > input";
        private string cssDateFrom = "#main > div > form > div.text.text-2.pl-md-4 > div.meta-wrap.m-2 > span > div > div > input[type=text]";
        private string cssDateTo = "#main > div > form > div.text.text-2.pl-md-4 > div.meta-wrap.m-2 > span:nth-child(2) > div > div > input[type=text]";
        private string cssCategory = "#main > div > form > div.text.text-2.pl-md-4 > div:nth-child(8) > div > div.rw-widget-input.rw-widget-picker.rw-widget-container > div > input";
        private string cssDivCategory = "#main > div > form > div.text.text-2.pl-md-4 > div:nth-child(8) > div > div.rw-widget-input.rw-widget-picker.rw-widget-container > div";
        private string cssDescription = "#main > div > form > div.text.text-2.pl-md-4 > div:nth-child(7) > div > div > textarea";
        private string cssBtnSave = "#main > div > form > div.row.pl-md-4 > div:nth-child(1) > button";
        private string cssNotEmptyPhoto = "#main > div > form > div.text.text-2.pl-md-4 > div.preview-container.valid > div > div > div > div.crop-container > div > div";
        private string cssInputRecurent = "div:nth-child(1) > .MuiFormControlLabel-root > .MuiCheckbox-root .PrivateSwitchBase-input-119";
        private string cssMapInput = "#main > div > form > div.text.text-2.pl-md-4 > div.MuiFormControl-root > div > label:nth-child(1) > span.MuiButtonBase-root.MuiIconButton-root.PrivateSwitchBase-root-116.MuiRadio-root.MuiRadio-colorSecondary.PrivateSwitchBase-checked-117.Mui-checked.MuiIconButton-colorSecondary > span.MuiIconButton-label > input";
        private string cssCheckTypeEvent = "#main > div > form > div.text.text-2.pl-md-4 > div.MuiFormControl-root > div > label:nth-child(2) > span.MuiButtonBase-root.MuiIconButton-root.PrivateSwitchBase-root-116.MuiRadio-root.MuiRadio-colorSecondary.PrivateSwitchBase-checked-117.Mui-checked.MuiIconButton-colorSecondary > span.MuiIconButton-label > div";
        private string xpathCollapsedListInventories = "//*[@id='main']/div/form/div[1]/div[12]/div[2]";
        private string idMapPosition = "map";
        private string cssEventCreateNotification = "#root > div.MuiSnackbar-root.MuiSnackbar-anchorOriginBottomLeft";
        private string cssEventBlock = "#main > div.events-container > div > div.col-12";
        public AddEvent(IWebDriver driver):base(driver)
        {
            photoDiv = Css(cssDivPhoto);
            btnCrop = Css(cssBtnCrop);
            title = Css(cssTitle);
            maxParticipants = Css(cssMaxPart);
            inputPublicEvent = Xpath(xPathPublicEvent);
            inputRecurentEvent = Css(cssInputRecurent);
            online = Xpath(xPathOnline);
            onlinePath = Css(cssOnlinePath);
            dateFrom = Css(cssDateFrom);
            dateTo = Css(cssDateTo);
            category = Css(cssCategory);
            divCategory = Css(cssDivCategory);
            description = Css(cssDescription);
            btnSave = Css(cssBtnSave);
            notEmptyPhoto = Css(cssNotEmptyPhoto);
            inputMap = Css(cssMapInput);
            eventType = Css(cssCheckTypeEvent);
            listInventories = Xpath(xpathCollapsedListInventories);
            mapPosition = Id(idMapPosition);
            eventCreateNotification = Css(cssEventCreateNotification);
            eventBlock = Css(cssEventBlock);
        }
        public bool IsPhotoVisible()
        {           
            try
            {
             
                IWebElement webElement = driver.FindElement(notEmptyPhoto);

                return webElement.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        public void CropClick()
        {
            Click(btnCrop);
        }
        public bool CropVisible()
        {
           return GetVisible(btnCrop);
        }
        public void SetTitle(string words)
        {
            SetInputField(title, words);
        }
        public string GetTitle()
        {
            return GetFieldValue(title);
        }
        public void SetMaxParticipants(string maxCount)
        {
            SetInputField(maxParticipants, maxCount);
        }
        public string GetMaxParticipants()
        {
            return GetFieldValue(maxParticipants);
        }
        public void SetPublicEvent()
        {
            CheckElement(inputPublicEvent);
        }
        public void SetOnlineEvent()
        {
            CheckElement(online);
        }
        public void SetOnlinePath(string path)
        {
            SetInputField(onlinePath, path);
        }
        public string GetOnlinePath()
        {
            return GetFieldValue(onlinePath);
        }
        
        public void SetDateFrom(int daysCount)
        {
            SetNextDaysOnTheRigth(dateFrom, daysCount);

        }
        public string GetDateFrom()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(dateFrom));
            IWebElement webElement = driver.FindElement(dateFrom);
            return webElement.GetAttribute("value");
        }
        public bool IsVisibleDateTo()
        {
           return GetVisible(dateTo);
        }
        public void SetDateTo(int daysCount)
        {
            SetNextDaysOnDown(dateTo, daysCount);
        }
        public void SetCategory(string categoryName)
        {
            SetValueSelect(category, categoryName);
        }
        public string GetCategory()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(divCategory));
             IWebElement webElement = driver.FindElement(divCategory);
            var s = webElement.Text;
            var result = Regex.Match(s, @"^([\w\-]+)");
            return result.ToString();
        }
        public void SetDescription(string descriptionText)
        {
            SetInputField(description, descriptionText);
        }
        public string GetDescription()
        {
           return GetTextArea(description);
        }

        public void Save()
        {
            Click(btnSave);
        }
        public void UploadPhoto(string photoPath)
        {
           
            IWebElement upload = driver.FindElement(photoDiv);
            upload.Click();
            Robot rb = new Robot();

            StringSelection str = new StringSelection(photoPath);
            Toolkit.getDefaultToolkit().getSystemClipboard().setContents(str, null);
            Thread.Sleep(500);
            rb.keyPress(KeyEvent.VK_CONTROL);
            rb.keyPress(KeyEvent.VK_V);
            rb.keyRelease(KeyEvent.VK_V);
            rb.keyRelease(KeyEvent.VK_CONTROL);
            rb.keyPress(KeyEvent.VK_TAB);
            rb.keyRelease(KeyEvent.VK_TAB);
            rb.keyPress(KeyEvent.VK_TAB);
            rb.keyRelease(KeyEvent.VK_TAB);
            rb.keyPress(KeyEvent.VK_SPACE);
            rb.keyRelease(KeyEvent.VK_SPACE);
            rb.delay(500);
        }
        public bool IsCheckedPublicEvent()
        {
            return HasClass(driver.FindElement(inputPublicEvent), BaseElementData.checkedPublicRecurrentClass);
        }
        public bool IsCheckedRecurentEvent()
        {
            return HasClass(driver.FindElement(inputRecurentEvent), BaseElementData.checkedPublicRecurrentClass);
        }
        public bool IsChoosenMapPosition()
        {
            return HasStyle(driver.FindElement(inputMap),BaseElementData.chooseMapPositionStyle);
        }
        public bool IsCollapsedEventInventories()
        {
           return !HasStyle(driver.FindElement(listInventories), BaseElementData.listIsInCollapsed);
        }

        private bool IsEventTypeVisible()
        {
            try
            {

                IWebElement webElement = driver.FindElement(eventType);

                return webElement.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        public bool IsOnlineChecked()
        {
            return IsEventTypeVisible();
        }
        public bool IsMapChecked()
        {
            return !IsEventTypeVisible();
        }

        public AddEvent ChooseMapPosition()
        {
            Click(mapPosition);
            return this;
        }
        public bool IsNotFilledMapPosition()
        {
            return HasClass(driver.FindElement(mapPosition), BaseElementData.requredDataClass);
        }
        public bool IsNotFilledOnlinePosition()
        {
            return HasClass(driver.FindElement(onlinePath), BaseElementData.requredDataClass);
        }
        public bool IsEventCreated()
        {
           return IsVisible(eventCreateNotification);
        }
        public int GetEventCount()
        {
            return GetElementsCount(eventBlock);
        }
    }
}
