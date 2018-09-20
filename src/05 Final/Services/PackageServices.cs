using Business;
using Domain;
using System.Collections.Generic;

namespace Services
{
    public class PackageServices : IPackageServices
    {
        private readonly IPackageBusiness _packageBusiness;

        public PackageServices(IPackageBusiness packageBusiness)
        {
            _packageBusiness = packageBusiness;
        }

        public void Delete(int id)
        {
            _packageBusiness.Delete(id);
        }

        public Package Get(int id)
        {
            return _packageBusiness.Get(id);
        }

        public ICollection<Package> Get()
        {
            return _packageBusiness.Get();
        }

        public Package Create(Package value)
        {
            return _packageBusiness.Create(value);
        }

        public Package Update(Package value)
        {
            _packageBusiness.Update(value);

            return value;
        }
    }
}
