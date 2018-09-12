using Itau.SE4.Commons;
using Itau.SE4.Entities;
using Itau.SE4.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Itau.SE4.Business
{
    public class ExamplePersonBusiness : IExamplePersonBusiness
    {
        IExamplePersonRepository _personRepository;

        public ExamplePersonBusiness(IExamplePersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        #region Métodos Publicos

        public ExamplePerson SavePerson(ExamplePerson person)
        {
            ValidateMaxAge(person);

            _personRepository.Create(person);

            ValidateAdvancedAge(person);

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

        #region Métodos Privados
        private void ValidateMaxAge(ExamplePerson person)
        {
            if (person.BirthDate < (DateTime.Today.AddYears(- ExamplesConstants.MAX_AGE)))
            {
                throw new BusinessException(ExamplesMessagesException.IDADE_NAO_PERMITIDA);
            }
        }

        private void ValidateAdvancedAge(ExamplePerson person)
        {
            if (person.BirthDate < (DateTime.Today.AddYears(-ExamplesConstants.WARNING_MAX_AGE)))
            {
                throw new BusinessException(ExamplesMessagesException.IDADE_AVANCADA);
            }
        }

        #endregion
    }
}
