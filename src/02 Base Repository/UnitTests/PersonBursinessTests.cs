using Moq;
using System;
using Tier.Business;
using Tier.Common;
using Tier.Entities;
using Tier.Repository;
using Xunit;

namespace UnitTests
{
    public class PersonBursinessTests
    {
        Mock<IPersonRepository> _personRepository;

        [Fact]
        public void ValidateMaxAge_ParticipanteForaDaIdade_test()
        {
            _personRepository = new Mock<IPersonRepository>();

            var app = new PersonBusiness(_personRepository.Object);

            var person = new Person()
            {
                Name = "Usuario 1",
                BirthDay = DateTime.Today.AddYears(-(Parameters.max_age + 1))
            };

            BusinessException ex = Assert.Throws<BusinessException>(() => app.SavePerson(person));

            Assert.Equal(ExceptionsMessages.IDADE_NAO_PERMITIDA, ex.Message);

        }

        [Fact]
        public void ValidateAvancedAge_ParticipanteDentroDaIdade_test()
        {
            _personRepository = new Mock<IPersonRepository>();
            
            var app = new PersonBusiness(_personRepository.Object);

            var person = new Person()
            {
                Id = 1,
                Name = "Usuario 1",
                BirthDay = DateTime.Today.AddYears(-(Parameters.warning_max_age + 1))
            };

            _personRepository.Setup(x => x.Create(It.IsAny<Person>())).Returns(person);

            BusinessException ex = Assert.Throws<BusinessException>(() => app.SavePerson(person));

            Assert.Equal(ExceptionsMessages.IDADE_AVANCADA, ex.Message);
            Assert.Equal((int)EnumExceptionLevel.ExceptionLevel.Warning, ex.Level);
        }
    }
}
