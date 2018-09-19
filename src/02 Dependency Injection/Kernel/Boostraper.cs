using Business;
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
        }
    }
}
