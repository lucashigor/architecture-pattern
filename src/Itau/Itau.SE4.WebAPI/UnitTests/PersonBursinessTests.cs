using Itau.SE4.Business;
using Itau.SE4.Commons;
using Itau.SE4.Entities;
using Itau.SE4.Repository;
using Moq;
using System;
using Xunit;

namespace UnitTests
{
    public class PersonBursinessTests
    {
        Mock<IExamplePersonRepository> _personRepository;
        ExamplesMessages _examplesMessages;

        public PersonBursinessTests()
        {
            _examplesMessages = new ExamplesMessages();
        }

        [Fact]
        public void ValidateMaxAge_ParticipanteForaDaIdade_test()
        {
            _personRepository = new Mock<IExamplePersonRepository>();

            var app = new ExamplePersonBusiness(_personRepository.Object, _examplesMessages);

            var person = new ExamplePerson()
            {
                Name = "Usuario 1",
                BirthDate = DateTime.Today.AddYears(-(ExamplesConstants.MAX_AGE + 1))
            };

            BusinessException ex = Assert.Throws<BusinessException>(() => app.SavePerson(person));

            Assert.Equal(_examplesMessages.GetIdadeNaoPermitida(), ex.Message);

        }

        [Fact]
        public void ValidateAvancedAge_ParticipanteDentroDaIdadeWarningDate_test()
        {
            _personRepository = new Mock<IExamplePersonRepository>();

            var app = new ExamplePersonBusiness(_personRepository.Object, _examplesMessages);

            var person = new ExamplePerson()
            {
                Id = 1,
                Name = "Usuario 1",
                BirthDate = DateTime.Today.AddYears(-(ExamplesConstants.WARNING_MAX_AGE + 1))
            };

            _personRepository.Setup(x => x.Create(It.IsAny<ExamplePerson>())).Returns(person);

            BusinessException ex = Assert.Throws<BusinessException>(() => app.SavePerson(person));

            Assert.Equal(_examplesMessages.GetIdadeAvancada(), ex.Message);
        }
    }
}
