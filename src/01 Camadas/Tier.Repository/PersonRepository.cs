using Tier.Entities;

namespace Tier.Repository
{
    public class PersonRepository
    {
        public Person CreatePerson(Person person)
        {
            person.Id = 1;
            return person;
        }
    }
}
