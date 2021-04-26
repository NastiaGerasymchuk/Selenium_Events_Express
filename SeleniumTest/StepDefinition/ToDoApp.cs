using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumTest.EventsExpressTests.Data;
using System;
using TechTalk.SpecFlow;

namespace SeleniumTest.StepDefinition
{
    [Binding]
    public class ToDoApp
    {
        String test_url = "https://lambdatest.github.io/sample-todo-app/";
        String itemName = "Adding item to the list";
        IWebDriver driver;

        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext context;
        public ToDoApp(ScenarioContext injectedContext)
        {
            context = injectedContext;
        }

        [Given(@"that I am on the LambdaTest Sample app")]
        public void GivenThatIAmOnTheLambdaTestSampleApp()
        {
            driver = new ChromeDriver(BaseConfigData.ChromeDriver);
            driver.Url = test_url;
            driver.Manage().Window.Maximize();
            System.Threading.Thread.Sleep(2000);
        }
        
        [Then(@"select the first item")]
        public void ThenSelectTheFirstItem()
        {
            IWebElement firstCheckBox = driver.FindElement(By.Name("li1"));
            firstCheckBox.Click();
        }
        
        [Then(@"select the second item")]
        public void ThenSelectTheSecondItem()
        {
            IWebElement secondCheckBox = driver.FindElement(By.Name("li2"));
            secondCheckBox.Click();
        }
        
        [Then(@"find the text box to enter the new value")]
        public void ThenFindTheTextBoxToEnterTheNewValue()
        {
            IWebElement textfield = driver.FindElement(By.Id("sampletodotext"));
            textfield.SendKeys(itemName);
        }
        
        [Then(@"click the Submit button")]
        public void ThenClickTheSubmitButton()
        {
            IWebElement addButton = driver.FindElement(By.Id("addbutton"));
            addButton.Click();
        }
        
        [Then(@"verify whether the item is added to the list")]
        public void ThenVerifyWhetherTheItemIsAddedToTheList()
        {
            // Verified Added Item name
            IWebElement itemtext = driver.FindElement(By.XPath("/html/body/div/div/div/ul/li[6]/span"));
            String getText = itemtext.Text;

            // Check if the newly added item is present or not using
            // Condition constraint (Boolean)
            Assert.That((itemName.Contains(getText)), Is.True);

            /* Perform wait to check the output */
            System.Threading.Thread.Sleep(2000);

            Console.WriteLine("Firefox - Test 1 Passed");
        }
        
        [Then(@"close the browser instance")]
        public void ThenCloseTheBrowserInstance()
        {
            driver.Quit();
        }
    }
}
