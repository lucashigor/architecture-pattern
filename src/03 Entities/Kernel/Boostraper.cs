using Business;
using CrossCulting;
using Domain;
using Repository;
using Services;
using Microsoft.Extensions.DependencyInjection;

namespace Kernel
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

            //Entities
            services.AddTransient<IPersonExampleValidator, PersonExampleValidator>();

            //Commons
            services.AddSingleton<IExamplesMessages, ExamplesMessages>();

        }
    }
}
