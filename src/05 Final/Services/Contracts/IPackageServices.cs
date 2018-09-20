using Domain;
using System.Collections.Generic;

namespace Services
{
    public interface IPackageServices
    {
        Package Get(int id);
        ICollection<Package> Get();
        Package Create(Package value);
        Package Update(Package value);
        void Delete(int id);
    }
}