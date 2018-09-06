using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace Cucumber
{
    [Binding]
    public class PesquisaNoGoogleSteps
    {
        IWebDriver driver;

        public PesquisaNoGoogleSteps()
        {
            driver = new ChromeDriver();
        }

        [When(@"eu precionar pesquisar")]
        public void QuandoEuPrecionarPesquisar()
        {
            driver.Navigate().GoToUrl("https://www.google.com");
        }

        [Given(@"que eu abri o google")]
        public void DadoQueEuAbriOGoogle()
        {
            driver.Manage().Window.Maximize();
        }

        [Given(@"digitei ""(.*)""")]
        public void DadoDigitei(string p0)
        {
            var sobre = driver.FindElement(By.Id("lst-ib"));
            sobre.SendKeys("calcanhar de aquiles");
            sobre.Submit();
        }

        [Then(@"o sistema apresenta a pesquisa")]
        public void EntaoOSistemaApresentaAPesquisa()
        {
            driver.Close();
            driver.Quit();
        }


    }
}
