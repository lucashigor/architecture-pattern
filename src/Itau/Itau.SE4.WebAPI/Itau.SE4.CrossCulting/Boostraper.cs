using Itau.SE4.Business;
using Itau.SE4.Repository;
using Itau.SE4.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Itau.SE4.CrossCulting
{
    public static class Boostraper
    {
        public static void Configure(IServiceCollection services)
        {
            //Services
            services.AddTransient<IExamplePersonServices, ExamplePersonServices>();

            //Business
            services.AddTransient<IExamplePersonBusiness, ExamplePersonBusiness>();

            //Repository
            services.AddTransient<IExamplePersonRepository, ExamplePersonRepository>();
            services.AddTransient<IContextFactory, ContextFactory>();
            services.AddTransient<IExamplePersonRepository, ExamplePersonRepository>();
        }
    }
}
