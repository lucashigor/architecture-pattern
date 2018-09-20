using Domain;
using Repository;
using System.Collections.Generic;
using System.Linq;

namespace Business
{
    public class PackageBusiness : IPackageBusiness
    {
        private readonly IPackageRepository _packageRepository;

        public PackageBusiness(IPackageRepository packageRepository)
        {
            _packageRepository = packageRepository;
        }

        public void Delete(int id)
        {
            _packageRepository.Delete(id);
        }

        public Package Get(int id)
        {
            return _packageRepository.GetById(id);
        }

        public ICollection<Package> Get()
        {
            return _packageRepository.GetAll().ToList();
        }

        public Package Create(Package value)
        {
            return _packageRepository.Create(value);
        }

        public Package Update(Package value)
        {
            _packageRepository.Update(value);

            return value;
        }
    }
}
