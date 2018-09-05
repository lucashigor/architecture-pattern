using SimpleInjector;
using Tier.Business;
using Tier.Repository;

namespace Tier.Common
{
    public static class Bootstrapper
    {
        public static void Configure(Container container)
        {
            container.Register<IFactoryBase, Factory>(Lifestyle.Scoped);

            //Business
            container.Register<IPersonBusiness, PersonBusiness>(Lifestyle.Scoped);

            //Repository
            container.Register<IPersonRepository, PersonRepository>(Lifestyle.Scoped);

        }
    }
}
