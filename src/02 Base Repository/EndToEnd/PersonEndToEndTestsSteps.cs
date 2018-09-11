using System;
using TechTalk.SpecFlow;
using System.Net.Http;
using System.Net.Http.Headers;
using WireMock.Logging;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;
using WireMock.Settings;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace EndToEnd
{
    [Binding]
    public class PersonEndToEndTestsSteps
    {
        [Given(@"I have entered (.*) into the calculator")]
        public async System.Threading.Tasks.Task GivenIHaveEnteredIntoTheCalculatorAsync(int p0)
        {
            var _server = FluentMockServer.Start(new FluentMockServerSettings
            {
                Urls = new[] { "http://localhost:53557/" },
                StartAdminInterface = true,
                ReadStaticMappings = true,
                WatchStaticMappings = true,
                //ProxyAndRecordSettings = new ProxyAndRecordSettings
                //{
                //    SaveMapping = true
                //},
                PreWireMockMiddlewareInit = app => { System.Console.WriteLine($"PreWireMockMiddlewareInit : {app.GetType()}"); },
                PostWireMockMiddlewareInit = app => { System.Console.WriteLine($"PostWireMockMiddlewareInit : {app.GetType()}"); },
                Logger = new WireMockConsoleLogger()
            });

            // Assign
            _server
              .Given(Request.Create().WithPath("/foo").UsingGet())
              .RespondWith(
                Response.Create()
                  .WithStatusCode(200)
                  .WithBody(@"{ ""msg"": ""Hello world!"" }")
              );

            // Act

            using (var client = new HttpClient())
            {
                client.BaseAddress = new System.Uri("http://localhost:53557/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync("/foo");
                if (response.IsSuccessStatusCode)
                {  //GET
                    string produto = await response.Content.ReadAsStringAsync();
                }
            }

            _server.Stop();

        }

        [When(@"I press add")]
        public void WhenIPressAdd()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost:56728/person.html");

            driver.Manage().Window.Maximize();

            //var sobre = driver.FindElement(By.Id("lst-ib"));
            //sobre.SendKeys("calcanhar de aquiles");
            //sobre.Submit();

            driver.Close();
            driver.Quit();
        }
        
        [Then(@"the result should be (.*) on the screen")]
        public void ThenTheResultShouldBeOnTheScreen(int p0)
        {
        }

        [Given(@"I have entered (.*) into the calculato")]
        public void GivenIHaveEnteredIntoTheCalculato(int p0)
        {
        }

    }
}
