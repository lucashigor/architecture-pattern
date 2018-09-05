using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Globalization;
using System.Web.Http;

namespace Tiers.Web
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        private static DefaultContractResolver contractResolver = new DefaultContractResolver
        {
            NamingStrategy = new SnakeCaseNamingStrategy()
        };

        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            //GlobalConfiguration.Configuration.MessageHandlers.Add(new Me)

            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings =
                new JsonSerializerSettings
                {
                    DateFormatHandling = DateFormatHandling.IsoDateFormat,
                    DateParseHandling = DateParseHandling.DateTimeOffset,
                    DateTimeZoneHandling = DateTimeZoneHandling.Utc,
                    Culture = CultureInfo.GetCultureInfo("en-US"),
                    ContractResolver = contractResolver
                };

            SimpleInjectorConfig.Configure();
        }
    }
}
