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
            services.AddTransient<IExamplePersonServices, ExamplePersonServices>();
            services.AddTransient<IContextFactory, ContextFactory>();
            services.AddTransient<IExamplePersonServices, ExamplePersonServices>();
            services.AddTransient<IAddressServices, AddressServices>();
            services.AddTransient<ICoupleServices, CoupleServices>();
            services.AddTransient<IDeliveryBoxServices, DeliveryBoxServices>();
            services.AddTransient<IEngagedServices, EngagedServices>();
            services.AddTransient<IPackageServices, PackageServices>();
            services.AddTransient<IPaymentPlanServices, PaymentPlanServices>();
            services.AddTransient<IPaymentServices, PaymentServices>();
            services.AddTransient<IWeddingServices, WeddingServices>();

            //Business
            services.AddTransient<IExamplePersonBusiness, ExamplePersonBusiness>();
            services.AddTransient<IExamplePersonBusiness, ExamplePersonBusiness>();
            services.AddTransient<IContextFactory, ContextFactory>();
            services.AddTransient<IExamplePersonBusiness, ExamplePersonBusiness>();
            services.AddTransient<IAddressBusiness, AddressBusiness>();
            services.AddTransient<ICoupleBusiness, CoupleBusiness>();
            services.AddTransient<IDeliveryBoxBusiness, DeliveryBoxBusiness>();
            services.AddTransient<IEngagedBusiness, EngagedBusiness>();
            services.AddTransient<IPackageBusiness, PackageBusiness>();
            services.AddTransient<IPaymentPlanBusiness, PaymentPlanBusiness>();
            services.AddTransient<IPaymentBusiness, PaymentBusiness>();
            services.AddTransient<IWeddingBusiness, WeddingBusiness>();

            //Repository
            services.AddTransient<IExamplePersonRepository, ExamplePersonRepository>();
            services.AddTransient<IContextFactory, ContextFactory>();
            services.AddTransient<IExamplePersonRepository, ExamplePersonRepository>();
            services.AddTransient<IAddressRepository, AddressRepository>();
            services.AddTransient<ICoupleRepository, CoupleRepository>();
            services.AddTransient<IDeliveryBoxRepository, DeliveryBoxRepository> ();
            services.AddTransient<IEngagedRepository, EngagedRepository> ();
            services.AddTransient<IPackageRepository, PackageRepository> ();
            services.AddTransient<IPaymentPlanRepository, PaymentPlanRepository> ();
            services.AddTransient<IPaymentRepository, PaymentRepository> ();
            services.AddTransient<IWeddingRepository, WeddingRepository> ();

            //Entities
            services.AddTransient<IPersonExampleValidator, PersonExampleValidator>();

            //Commons
            services.AddSingleton<IExamplesConstants, ExamplesConstants>();
            services.AddSingleton<IExamplesMessages, ExamplesMessages>();
            services.AddSingleton<IFeature, Feature>();
        }
    }
}
