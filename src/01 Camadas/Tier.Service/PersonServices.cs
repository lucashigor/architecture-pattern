using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tier.Business;
using Tier.Entities;
using Tier.Repository;

namespace Tier.Service
{
    public class PersonServices
    {
        PersonBusiness personBusiness;
        PersonRepository personRepository;

        public PersonServices()
        {
            personBusiness = new PersonBusiness();
            personRepository = new PersonRepository();
        }

        public Person SavePerson(Person person)
        {
            personBusiness.ValidateMaxAge(person);

            personRepository.CreatePerson(person);

            personBusiness.ValidateAdvancedAge(person);

            return person;
        }
    }
}
