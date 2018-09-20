using EntityPhoto;
using System.Collections.Generic;

namespace Services
{
    public interface IEngagedServices
    {
        void Delete(Engaged engaged, bool commit);
        ICollection<Engaged> Get();
        Engaged Get(int id);
        Engaged Post(Engaged value);
        Engaged Put(int id, Engaged value);
        void Delete(int id, bool commit);
    }
}