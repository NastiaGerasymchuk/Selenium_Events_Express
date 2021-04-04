﻿

// Generated by Selenium IDE
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using NUnit.Framework;
namespace SeleniumTest
{
    [TestFixture]
    public class EventSelenium
    {
        private IWebDriver driver;
        public IDictionary<string, object> vars { get; private set; }
        private IJavaScriptExecutor js;
        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver(@"C:\Users\Admin\Desktop");

            js = (IJavaScriptExecutor)driver;
            vars = new Dictionary<string, object>();
        }
        [TearDown]
        protected void TearDown()
        {
            //driver.Quit();
            //driver.Close();
        }
       
       
        [Test]


        public void test1()
        {
            driver.Navigate().GoToUrl("https://localhost:44344/home/events?page=1&status=active");
            driver.Manage().Window.Size = new System.Drawing.Size(1587, 969);
            driver.FindElement(By.Name("keyWord")).Click();
            driver.FindElement(By.Name("keyWord")).SendKeys("sea");
            //driver.FindElement(By.Name("keyWord")).SendKeys(Keys.Enter);
            //driver.FindElement(By.CssSelector(".MuiButton-textSecondary > .MuiButton-label")).Click();
            //driver.FindElement(By.Id("notfound")).Click();
            ////driver.FindElement(By.CssSelector(".rw-input-reset")).Click();
            ////driver.FindElement(By.CssSelector(".rw-list-option:nth-child(2)")).Click();
            //driver.FindElement(By.CssSelector(".MuiButtonBase-root:nth-child(2) > .MuiButton-label")).Click();
            Assert.That(driver.FindElement(By.CssSelector(".h1")).Text, Is.EqualTo("No Results"));
        }
    }
}