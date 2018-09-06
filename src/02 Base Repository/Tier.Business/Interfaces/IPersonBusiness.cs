using System.Collections.Generic;
using Tier.Entities;

namespace Tier.Business
{
    public interface IPersonBusiness
    {
        Person SavePerson(Person person);

        ICollection<Person> GetCollection();

        void Delete(Person person);

        void Delete(int id);

        Person Get(int Id);
    }
}
