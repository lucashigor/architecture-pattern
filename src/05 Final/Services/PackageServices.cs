using System.Collections.Generic;
using System.Linq;
using DBAccess;
using EntityPhoto;

namespace Services
{
    public class PackageServices : IPackageServices
    {
        private readonly IUnitOfWork _unityWork;

        public PackageServices(IUnitOfWork unityWork)
        {
            _unityWork = unityWork;
        }

        public void Delete(int id)
        {
            _unityWork.PackageRepository.Delete(x => x.Id == id);
            Commit();
        }

        public Package Get(int id)
        {
            return _unityWork.PackageRepository.GetById(id);
        }

        public ICollection<Package> Get()
        {
            return _unityWork.PackageRepository.GetAll().ToList();
        }

        public Package Post(Package value)
        {
            return _unityWork.PackageRepository.Create(value);
        }

        public Package Put(int id, Package value)
        {
            var package = _unityWork.PackageRepository.GetById(id);

            if(value.Name != null)
            {
                package.Name = value.Name;
            }

            _unityWork.PackageRepository.Update(package);

            Commit();

            return package;
        }

        public void Commit()
        {
            _unityWork.Commit();
        }
    }
}
