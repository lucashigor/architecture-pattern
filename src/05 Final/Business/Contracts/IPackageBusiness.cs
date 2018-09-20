using Domain;
using System.Collections.Generic;

namespace Business
{
    public interface IPackageBusiness
    {
        Package Get(int id);
        ICollection<Package> Get();
        Package Create(Package value);
        Package Update(Package value);
        void Delete(int id);
    }
}