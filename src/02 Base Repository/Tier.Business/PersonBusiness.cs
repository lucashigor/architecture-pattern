using System;
using System.Collections.Generic;
using System.Linq;
using Tier.Common;
using Tier.Entities;
using Tier.Repository;

namespace Tier.Business
{
    public class PersonBusiness : IPersonBusiness
    {
        IPersonRepository _personRepository;

        public PersonBusiness(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public Person SavePerson(Person person)
        {
            ValidateMaxAge(person);

            _personRepository.Create(person);

            ValidateAdvancedAge(person);

            return person;
        }

        #region Métodos Privados
        private void ValidateMaxAge(Person person)
        {
            if (person.BirthDay < (DateTime.Today.AddYears(-Parameters.max_age)))
            {
                throw new BusinessException(ExceptionsMessages.IDADE_NAO_PERMITIDA
                                            , (int)EnumExceptionLevel.ExceptionLevel.Error
                                            , ExceptionsMessages.COD_IDADE_NAO_PERMITIDA);
            }
        }

        private void ValidateAdvancedAge(Person person)
        {
            if (person.BirthDay < (DateTime.Today.AddYears(-Parameters.warning_max_age)))
            {
                throw new BusinessException(ExceptionsMessages.IDADE_AVANCADA
                                            , (int)EnumExceptionLevel.ExceptionLevel.Warning
                                            , ExceptionsMessages.COD_IDADE_AVANCADA);
            }
        }

        public ICollection<Person> GetCollection()
        {
            return _personRepository.GetAll().ToList();
        }
        #endregion
    }
}
