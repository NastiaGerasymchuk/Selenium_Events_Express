using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumTest.EventsExpressTests.Data;

namespace SeleniumTest.EventsExpressTests.Helpers
{
    public static class BrowserConfig
    {
        public static IWebDriver GetDriver()
        {
            IWebDriver driver= new ChromeDriver(BaseConfigData.ChromeDriver);
            return driver;
        }
        public static void CloseDriver(this IWebDriver driver)
        {
            driver.Close();
        }
    }
}
