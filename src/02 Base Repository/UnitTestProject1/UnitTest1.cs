using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.google.com");

            driver.Manage().Window.Maximize();

            var sobre = driver.FindElement(By.Id("lst-ib"));
            sobre.SendKeys("calcanhar de aquiles");
            sobre.Submit();

            driver.Close();
            driver.Quit();
        }
    }
}
