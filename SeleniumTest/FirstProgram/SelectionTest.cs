using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumTest.FirstProgram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumTest
{
   [TestFixture]
   public class SelectionTest
    {
        private string _pagePath = "https://demosite.executeautomation.com/";
        

        [SetUp]
        public void Initialize()
        {
            Driver.driver = new ChromeDriver(@"C:\Users\Admin\Desktop");
            Driver.driver.Manage().Window.Maximize();
            Driver.driver.Navigate().GoToUrl(_pagePath);
        }

        [Test]
        [Obsolete]
        public void ChooseElements()
        {
            LogInForm logInForm = new LogInForm();

            PageElements pageElements = logInForm.Login("Nastia", "78789878");
            Thread.Sleep(3000);
            pageElements.SetUser("Some text", "Nastia", "Gerasymchuk", "Ms.");
            
            //pageElements.initiaTxt.SendKeys("Some text");
            //pageElements.radioElement.Click();
            //pageElements.checkBoxElement.Click();
            //Selection.SendKeys(Type.Id, _initiaId, _initiaValue);
            //Selection.SelectElements(Type.Id, _selectId, _selectValue);
            //Selection.ClickElement(Type.Name, _radioName);
            //Selection.ClickElement(Type.Name, _checkBoxName);
            //Console.WriteLine(Getting.GetInputValue(Type.Id, _initiaId));
            //Console.WriteLine(Getting.GetSelectElement(Type.Id, _selectId));

        }

        [TearDown]
        public void Close()
        {
            //_driver.Close();
        }
    }
}
