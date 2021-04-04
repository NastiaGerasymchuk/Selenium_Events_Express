using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTest.EventsExpressTests
{
   public class FilterByLocation
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        private string cssTitle = "#form-dialog-title > h6";
        private string nameInputradius = "radius";
        private string cssBtnCancel = "body > div.MuiDialog-root > div.MuiDialog-container.MuiDialog-scrollPaper > div > div.MuiDialogActions-root.MuiDialogActions-spacing > button:nth-child(1)";
        private string cssBtnFiler = "body > div.MuiDialog-root > div.MuiDialog-container.MuiDialog-scrollPaper > div > div.MuiDialogActions-root.MuiDialogActions-spacing > button:nth-child(3)";

        [FindsBy(How = How.CssSelector, Using = "#form-dialog-title > h6")]
        IWebElement filterTitle;
        [FindsBy(How = How.Name, Using = "radius")]
        IWebElement radiusSlider;
        [FindsBy(How = How.Id, Using = "map")]
        IWebElement divMap;
        [FindsBy(How = How.CssSelector, Using = "body > div.MuiDialog-root > div.MuiDialog-container.MuiDialog-scrollPaper > div > div.MuiDialogContent-root > div:nth-child(3) > div:nth-child(1)")]
        IWebElement divLat;
        [FindsBy(How = How.CssSelector, Using = "body > div.MuiDialog-root > div.MuiDialog-container.MuiDialog-scrollPaper > div > div.MuiDialogContent-root > div:nth-child(3) > div:nth-child(2)")]
        IWebElement divLng;
        [FindsBy(How = How.CssSelector, Using = "body > div.MuiDialog-root > div.MuiDialog-container.MuiDialog-scrollPaper > div > div.MuiDialogActions-root.MuiDialogActions-spacing > button:nth-child(1)")]
        IWebElement btnCancel;
        [FindsBy(How = How.CssSelector, Using = "body > div.MuiDialog-root > div.MuiDialog-container.MuiDialog-scrollPaper > div > div.MuiDialogActions-root.MuiDialogActions-spacing > button:nth-child(2)")]
        IWebElement btnFilter;

        [Obsolete]
        public FilterByLocation(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            PageFactory.InitElements(driver, this);
        }

        [Obsolete]
        public string GetTitleFilter()
        {
           return wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(cssTitle))).Text;
        }

        [Obsolete]
        public void SetRadiusValue(string radius)
        {
            //IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
            //jse.ExecuteScript("arguments[0].value='" + radius + "';", radiusSlider);
            int x = Convert.ToInt32(radius);
            int width = 552;
            Actions act = new Actions(driver);
            act.MoveToElement(radiusSlider, ((width * x) / 10000), 0).Click();
            act.Build().Perform();

            // wait.Until(ExpectedConditions.ElementIsVisible(By.Name(nameInputradius))).setAttribute("value", "your value");

        }

        [Obsolete]
        public string GetRadiusValue()
        {
           return wait.Until(ExpectedConditions.ElementIsVisible(By.Name(nameInputradius))).GetAttribute("value");
        }
        [Obsolete]
        public void ClearRadiusValue()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.Name(nameInputradius))).Clear();
        }
        [Obsolete]
        public FilterByLocation ClickCancelBtn()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(cssBtnCancel))).Click();
            return this;
        }
        [Obsolete]
        public HomeEvent ClickFilterBtn()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(cssBtnFiler))).Click();
            return new HomeEvent(driver);
        }
    }
}
