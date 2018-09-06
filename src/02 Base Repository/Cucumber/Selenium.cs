using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Cucumber
{
    [TestFixture]
    public class Selenium
    {
        [Test]
        public void TestMethod1()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.google.com");

            driver.Manage().Window.Maximize();

            var sobre = driver.FindElement(By.Id("q"));
            sobre.Text.Equals("calcanhar de aquiles");

            driver.Close();
            driver.Quit();
        }
    }
}
