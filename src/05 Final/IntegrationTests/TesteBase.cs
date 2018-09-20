using Kernel;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace IntegrationTests
{
    public class TesteBase
    {
        private readonly IServiceCollection serviceCollection = new ServiceCollection();
        private readonly IConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
        protected readonly IServiceProvider serviceProvider;

        public TesteBase()
        {
            Boostraper.Configure(serviceCollection);

            configurationBuilder.AddJsonFile("appsettings.test.json");
            IConfiguration Configuration = configurationBuilder.Build();

            serviceCollection.AddSingleton<IConfiguration>(Configuration);

            serviceProvider = serviceCollection.BuildServiceProvider();
        }
    }
}
