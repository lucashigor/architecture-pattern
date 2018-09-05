using Tier.Business;
using Tier.Entities;

namespace Tier.Service
{
    public class PersonServices
    {
        IPersonBusiness _personBusiness;

        public PersonServices(IPersonBusiness personBusiness)
        {
            _personBusiness = personBusiness;
        }

        public Person SavePerson(Person person)
        {
            _personBusiness.SavePerson(person);
            
            return person;
        }
    }
}
