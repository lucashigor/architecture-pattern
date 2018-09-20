using Domain;
using System.Collections.Generic;

namespace Services
{
    public interface IEngagedServices
    {
        void Delete(Engaged engaged);
        ICollection<Engaged> Get();
        Engaged Get(int id);
        Engaged Create(Engaged value);
        Engaged Update(Engaged value);
        void Delete(int id);
    }
}