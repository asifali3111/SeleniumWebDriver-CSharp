using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SeleniumWebDriver_CSharp
{
    [TestClass]
    public class UnitTest1
    {
        ChromeDriver chromeDriver = null;
               

        [TestInitialize]
        public void SetUp()
        {
            Console.Out.WriteLine("-> Run Test Initialize");
            chromeDriver = new ChromeDriver(@"C:\\Users\\Asif Ali\\Downloads\\chromedriver_win32");
            chromeDriver.Navigate().GoToUrl("http://www.google.co.uk");
        }

        [TestMethod]
        public void TestMethod1()
        {
            Console.Out.WriteLine("Run Test Method 1");
            //chromeDriver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            chromeDriver.FindElement(By.Id("lst-ib")).SendKeys("water ltd");
            chromeDriver.FindElement(By.Id("lst-ib")).SendKeys(Keys.Enter);
            WebDriverWait wait = new WebDriverWait(chromeDriver, new TimeSpan(0, 0, 5));
            IWebElement firstElement = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("#rso > div > div:nth-child(1) > div > h3 > a")));

            String firstElementURL = firstElement.GetAttribute("href");
            Console.Out.WriteLine("href = " + firstElementURL);

            chromeDriver.Navigate().GoToUrl(firstElementURL);
            
            System.Console.WriteLine("Page title is: " + chromeDriver.Title);
            System.Console.WriteLine("Page address is: " + chromeDriver.Url);
        }

        //[TestMethod]
        public void TestMethod2()
        {
            Console.Out.WriteLine("Run Test Method 2");
        }

        // This closes the driver down after the test has finished.
        [TestCleanup]
        public void TearDown()
        {
            Console.Out.WriteLine("-> Run Test Cleanup");
            chromeDriver.Quit();
        }
    }
}
