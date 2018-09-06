using System.Collections.Generic;
using Tier.Entities;

namespace Tier.Service
{
    public interface IPersonService
    {
        Person SavePerson(Person person);

        ICollection<Person> GetCollection();
    }
}
