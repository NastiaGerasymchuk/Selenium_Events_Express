using com.sun.org.apache.bcel.@internal.generic;
using java.awt;
using java.awt.datatransfer;
using java.awt.@event;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumTest.EventsExpressTests.Data;
using SeleniumTest.EventsExpressTests.Enum;
using SeleniumTest.EventsExpressTests.Pages;
using System;
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
        private By periodicity;
        private By frequency;
        private By datefrom;
        private By addedPhoto;
        private string cssDivPhoto = "#main > div > form > div.text.text-2.pl-md-4 > div.preview-container.valid > div > div";
        private string cssBtnCrop = "#main > div > form > div.text.text-2.pl-md-4 > div.preview-container.valid > div > div > div > div.controls > button";
        private string cssTitle = "#main > div > form > div.text.text-2.pl-md-4 > div:nth-child(2) > div > div > input";
        private string cssMaxPart = "#main > div > form > div.text.text-2.pl-md-4 > div:nth-child(3) > div > div > input";
        private string xPathPublicEvent = "//*[@id='main']/div/form/div[1]/div[5]/div/label/span[1]"; 
        
        private string xPathOnline = "/html/body/div/div[3]/div/form/div[1]/div[10]/div/label[2]/span[1]/span[1]/input";
        private string cssOnlinePath = "#main > div > form > div.text.text-2.pl-md-4 > div:nth-child(11) > div > div > input";
        private string cssDateFrom = "#main > div > form > div.text.text-2.pl-md-4 > div.meta-wrap.m-2 > span > div > div > input[type=text]";
        private string cssDateTo = "#main > div > form > div.text.text-2.pl-md-4 > div.meta-wrap.m-2 > span:nth-child(2) > div > div > input[type=text]";
        private string cssCategory = "#main > div > form > div.text.text-2.pl-md-4 > div:nth-child(8) > div > div.rw-widget-input.rw-widget-picker.rw-widget-container > div > input";
        private string cssDivCategory = "#main > div > form > div.text.text-2.pl-md-4 > div:nth-child(8) > div > div.rw-widget-input.rw-widget-picker.rw-widget-container > div";
        private string cssDescription = "#main > div > form > div.text.text-2.pl-md-4 > div:nth-child(7) > div > div > textarea";
        private string cssBtnSave = "#main > div > form > div.row.pl-md-4 > div:nth-child(1) > button";
        private string cssNotEmptyPhoto = "#main > div > form > div.text.text-2.pl-md-4 > div.preview-container.valid > div > div > div > div.crop-container > div > div";
        private string xPathInputRecurent = "//*[@id='main']/div/form/div[1]/div[4]/div/label/span[1]/span[1]/input";
        private string cssMapInput = "#main > div > form > div.text.text-2.pl-md-4 > div.MuiFormControl-root > div > label:nth-child(1) > span.MuiButtonBase-root.MuiIconButton-root.PrivateSwitchBase-root-116.MuiRadio-root.MuiRadio-colorSecondary.PrivateSwitchBase-checked-117.Mui-checked.MuiIconButton-colorSecondary > span.MuiIconButton-label > input";
        private string cssCheckTypeEvent = "#main > div > form > div.text.text-2.pl-md-4 > div.MuiFormControl-root > div > label:nth-child(2) > span.MuiButtonBase-root.MuiIconButton-root.PrivateSwitchBase-root-116.MuiRadio-root.MuiRadio-colorSecondary.PrivateSwitchBase-checked-117.Mui-checked.MuiIconButton-colorSecondary > span.MuiIconButton-label > div";
        private string xpathCollapsedListInventories = "//*[@id='main']/div/form/div[1]/div[12]/div[2]";
        private string idMapPosition = "map";
        private string cssEventCreateNotification = "#root > div.MuiSnackbar-root.MuiSnackbar-anchorOriginBottomLeft";
        private string cssEventBlock = "#main > div.events-container > div > div.col-12";
        private string idPeriodicity = "age-native-simple";
        private string nameFrequelcy = "frequency";
        private string cssDataFrom = "#main > div > form > div.text.text-2.pl-md-4 > div.meta-wrap.m-2 > span:nth-child(1) > div > div > input[type=text]";
        private string cssAddedPhoto = "#main > div > form > div.text.text-2.pl-md-4 > div.preview-container.valid > div > div > div > img";
        public AddEvent(IWebDriver driver):base(driver)
        {
            photoDiv = Css(cssDivPhoto);
            btnCrop = Css(cssBtnCrop);
            title = Css(cssTitle);
            maxParticipants = Css(cssMaxPart);
            inputPublicEvent = Xpath(xPathPublicEvent);
            inputRecurentEvent = Xpath(xPathInputRecurent);
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
            periodicity = Id(idPeriodicity);
            frequency = Name(nameFrequelcy);
            datefrom = Css(cssDataFrom);
            addedPhoto = Css(cssAddedPhoto);
        }

        [Obsolete]
        public bool IsPhotoVisible()
        {
            return Visible(notEmptyPhoto);      
            //try
            //{
             
            //    IWebElement webElement = driver.FindElement(notEmptyPhoto);

            //    return webElement.Displayed;
            //}
            //catch (NoSuchElementException)
            //{
            //    return false;
            //}
        }

        [Obsolete]
        public bool IsPresentAddedPhoto()
        {
            return Visible(addedPhoto);
        }

        [Obsolete]
        public bool IsPeriodicityVisible()
        {
            return Visible(periodicity);
            //return GetVisible(periodicity);

        }

        [Obsolete]
        public bool IsFrequencyVisible()
        {
            return Visible(frequency);
            //return GetVisible(frequency);

        }
        public AddEvent SetFrequency(string count)
        {
            SetInputField(frequency, count);
            return this;
        }

        [Obsolete]
        public bool Visible(By by)
        {
            try
            {
                IWebElement webElement = driver.FindElement(by);

                return true;
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
        public void SetReccurentEvent()
        {
            CheckElement(inputRecurentEvent);
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
            return new AddEvent(driver);
        }
        public bool IsNotFilledMapPosition()
        {
            return HasClass(driver.FindElement(mapPosition), BaseElementData.requredDataClass);
        }
        public bool IsNotFilledOnlinePosition()
        {
            return HasClass(driver.FindElement(onlinePath), BaseElementData.requredDataClass);
        }

        [System.Obsolete]
        public bool IsEventCreated()
        {
            try
            {

                wait.Until(ExpectedConditions.ElementIsVisible(eventCreateNotification));

                IWebElement webElement = driver.FindElement(eventCreateNotification);
                return true;
                //return webElement.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        public int GetEventCount()
        {
            return GetElementsCount(eventBlock);
        }

        public AddEvent ChooseDailyOption()
        {
            return SetPeriodicity(Periodicity.Daily);
        }
        public AddEvent ChooseWeeklyOption()
        {
            return SetPeriodicity(Periodicity.Weerly);
        }
        public AddEvent ChooseMonthlyOption()
        {
            return SetPeriodicity(Periodicity.Monthly);
        }
        public AddEvent ChooseYearlyOption()
        {
            return SetPeriodicity(Periodicity.Yearly);
        }
        public AddEvent SetPeriodicity(Periodicity period)
        {
            IWebElement webElement = driver.FindElement(By.Id(idPeriodicity));
            Click(periodicity);
            for(int i = 0; i < (int)period; i++)
            {
                webElement.SendKeys(Keys.ArrowDown);
            }            
            webElement.SendKeys(Keys.Enter);
            return this;
        }
    }
}
