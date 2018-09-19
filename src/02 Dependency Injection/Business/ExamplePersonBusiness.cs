using Domain;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business
{
    public class ExamplePersonBusiness : IExamplePersonBusiness
    {
        private readonly IExamplePersonRepository _personRepository;

        public ExamplePersonBusiness(IExamplePersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        #region Métodos Publicos

        public ExamplePerson SavePerson(ExamplePerson person)
        {
            _personRepository.Create(person);

            return person;
        }

        public ExamplePerson UpdatePerson(ExamplePerson person)
        {
            _personRepository.Update(person);

            return person;
        }

        public ICollection<ExamplePerson> GetCollection()
        {
            return _personRepository.GetAll().ToList();
        }

        public ExamplePerson Get(int Id)
        {
            return _personRepository.GetById(Id);
        }


        public void Delete(ExamplePerson person)
        {
            _personRepository.DeleteByCpf(person.Cpf);
        }

        public void Delete(int id)
        {
            _personRepository.Delete(id);
        }

        #endregion
    }
}
