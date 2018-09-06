using SimpleInjector;
using Tier.Business;
using Tier.Repository;
using Tier.Service;

namespace Tier.Common
{
    public static class Bootstrapper
    {
        public static void Configure(Container container)
        {
            container.Register<IFactoryBase, Factory>(Lifestyle.Transient);

            //Service
            container.Register<IPersonService, PersonService>(Lifestyle.Transient);

            //Business
            container.Register<IPersonBusiness, PersonBusiness>(Lifestyle.Transient);

            //Repository
            container.Register<IPersonRepository, PersonRepository>(Lifestyle.Transient);

        }
    }
}
