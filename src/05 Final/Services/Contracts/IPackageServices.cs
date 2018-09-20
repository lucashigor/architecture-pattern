using EntityPhoto;
using System.Collections.Generic;

namespace Services
{
    public interface IPackageServices
    {
        Package Get(int id);
        ICollection<Package> Get();
        Package Post(Package value);
        Package Put(int id, Package value);
        void Delete(int id);
    }

}