using Business;
using CrossCulting;
using Domain;
using Repository;
using Moq;
using System;
using Xunit;
using TestsCommons;

namespace UnitTests
{
    public class PersonBursinessTests
    {
        Mock<IExamplePersonRepository> _personRepository;
        Mock<IExamplesMessages> _examplesMessages;
        Mock<IExamplesConstants> _examplesConstants;

        public PersonBursinessTests()
        {
            _examplesMessages = new Mock<IExamplesMessages>();

            _examplesMessages.Setup(x => x.GetIdadeNaoPermitida()).Returns("GetIdadeNaoPermitida");
            _examplesMessages.Setup(x => x.GetIdadeAvancada()).Returns("GetIdadeAvancada");

            _examplesConstants = new Mock<IExamplesConstants>();

            _examplesConstants.Setup(x => x.GetMaxAge()).Returns(50);
            _examplesConstants.Setup(x => x.GetWarningMaxAge()).Returns(45);

        }

        [Fact]
        public void ValidateMaxAge_ParticipanteForaDaIdade_Ex_test()
        {
            //Setup
            _personRepository = new Mock<IExamplePersonRepository>();

            var app = new ExamplePersonBusiness(_personRepository.Object, _examplesMessages.Object, _examplesConstants.Object);

            var person = GenerateEntity.GenerateExamplePerson(null
                                                             ,null
                                                             ,DateTime.Today.AddYears(-(_examplesConstants.Object.GetMaxAge() + 1))
                                                             ,null);

            //Fact
            BusinessException ex = Assert.Throws<BusinessException>(() => app.SavePerson(person));

            //Assert
            Assert.Equal(_examplesMessages.Object.GetIdadeNaoPermitida(), ex.Message);
        }

        [Fact]
        public void ValidateAvancedAge_ParticipanteDentroDaIdadeMasWarningDate_Ex_test()
        {
            //Setup
            _personRepository = new Mock<IExamplePersonRepository>();

            var app = new ExamplePersonBusiness(_personRepository.Object, _examplesMessages.Object, _examplesConstants.Object);

            var person = GenerateEntity.GenerateExamplePerson(null
                                                             , null
                                                             , DateTime.Today.AddYears(-(_examplesConstants.Object.GetWarningMaxAge() + 1))
                                                             , null);

            _personRepository.Setup(x => x.Create(It.IsAny<ExamplePerson>())).Returns(person);

            //Fact
            BusinessException ex = Assert.Throws<BusinessException>(() => app.SavePerson(person));

            //Assert
            Assert.Equal(_examplesMessages.Object.GetIdadeAvancada(), ex.Message);
        }

        [Fact]
        public void ValidateAvancedAge_ParticipanteDentroDaIdade_Success_test()
        {
            //Setup
            _personRepository = new Mock<IExamplePersonRepository>();

            var app = new ExamplePersonBusiness(_personRepository.Object, _examplesMessages.Object, _examplesConstants.Object);

            var person = GenerateEntity.GenerateExamplePerson(null
                                                             , null
                                                             , DateTime.Today.AddYears(-(_examplesConstants.Object.GetWarningMaxAge() - 1))
                                                             , null);

            _personRepository.Setup(x => x.Create(It.IsAny<ExamplePerson>())).Returns(person);

            //Fact
            app.SavePerson(person);
        }

    }
}
