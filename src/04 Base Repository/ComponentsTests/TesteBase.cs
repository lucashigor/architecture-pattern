using Kernel;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ComponentsTests
{
    public class TesteBase
    {
        private readonly IServiceCollection serviceCollection = new ServiceCollection();
        private readonly IConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
        public readonly IServiceProvider serviceProvider;

        private static TesteBase _testeBase;

        private TesteBase()
        {
            Boostraper.Configure(serviceCollection);

            configurationBuilder.AddJsonFile("appsettings.test.json");
            IConfiguration Configuration = configurationBuilder.Build();

            serviceCollection.AddSingleton<IConfiguration>(Configuration);

            serviceProvider = serviceCollection.BuildServiceProvider();
        }

        public static TesteBase GetInstance()
        {
            return _testeBase ?? (_testeBase = new TesteBase());
        }


    }
}
