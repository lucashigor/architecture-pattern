using Kernel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Repository;
using System;

namespace ComponentsTests
{
    public class TesteBase
    {
        private readonly IServiceCollection serviceCollection = new ServiceCollection();
        private readonly IConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
        public readonly IServiceProvider serviceProvider;

        private readonly Mock<IContextFactory> _contextFactory;

        private static TesteBase _testeBase;

        private TesteBase()
        {
            _contextFactory = new Mock<IContextFactory>();

            Boostraper.Configure(serviceCollection);

            configurationBuilder.AddJsonFile("appsettings.test.json");
            IConfiguration Configuration = configurationBuilder.Build();

            var bagulho = new DbContextOptionsBuilder<PhotoAdminContext>()
                .UseInMemoryDatabase(databaseName: "Add_writes_to_database")
                .Options;

            _contextFactory.Setup(x => x.GetContext()).Returns(new PhotoAdminContext(bagulho));

            serviceCollection.AddSingleton<IContextFactory>(_contextFactory.Object);
            serviceCollection.AddSingleton<IConfiguration>(Configuration);

            serviceProvider = serviceCollection.BuildServiceProvider();
        }

        public static TesteBase GetInstance()
        {
            return _testeBase ?? (_testeBase = new TesteBase());
        }


    }
}
