using Business;
using CrossCulting;
using Domain;
using Microsoft.Extensions.DependencyInjection;
using Repository;
using Services;

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
            services.AddSingleton<IExamplesConstants, ExamplesConstants>();
            services.AddSingleton<IExamplesMessages, ExamplesMessages>();
            services.AddSingleton<IFeature, Feature>();
        }
    }
}
