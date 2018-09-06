using System.Collections.Generic;
using Tier.Business;
using Tier.Entities;

namespace Tier.Service
{
    public class PersonService : IPersonService
    {
        IPersonBusiness _personBusiness;

        public PersonService(IPersonBusiness personBusiness)
        {
            _personBusiness = personBusiness;
        }

        public ICollection<Person> GetCollection()
        {
            return _personBusiness.GetCollection();
        }

        public Person SavePerson(Person person)
        {
            _personBusiness.SavePerson(person);
            
            return person;
        }

        public void DeletePerson(Person person)
        {
            _personBusiness.Delete(person);
        }

        public void DeletePerson(int Id)
        {
            _personBusiness.Delete(Id);
        }

        public Person Get(int Id)
        {
            return _personBusiness.Get(Id);
        }
    }
}
