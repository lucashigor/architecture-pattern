using CrossCulting;
using Domain;
using Moq;
using System;
using TestsCommons;
using Xunit;

namespace UnitTests
{
    public class PersonExampleValidatorTests
    {
        private readonly Mock<IExamplesMessages> _examplesMessages;
        private readonly PersonExampleValidator app;

        public PersonExampleValidatorTests()
        {
            _examplesMessages = new Mock<IExamplesMessages>();

            _examplesMessages.Setup(x => x.GetNameRequired(It.IsAny<string>())).Returns("GetNameRequired");
            _examplesMessages.Setup(x => x.GetMaxLenght(It.IsAny<string>(), It.IsAny<string>())).Returns("GetMaxLenght");

            app = new PersonExampleValidator(_examplesMessages.Object);
        }

        [Fact]
        public void Validar_NomeNaoPreenchido_Ex_test()
        {
            //Setup
            var person = GenerateEntity.GenerateExamplePerson( null
                                                              , ""
                                                              , null
                                                              , null);
            //Fact
            ValidationException ex = Assert.Throws<ValidationException>(() => app.Validar(person));

            //Assert
            Assert.Equal("GetNameRequired", ex.Erros[0]);

        }

        [Fact]
        public void Validar_NomeMuitoGrande_Ex_test()
        {
            //Setup
            var person = GenerateEntity.GenerateExamplePerson(null
                                                              , "12345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901"
                                                              , null
                                                              , null);
            //Fact
            ValidationException ex = Assert.Throws<ValidationException>(() => app.Validar(person));

            //Assert
            Assert.Equal("GetMaxLenght", ex.Erros[0]);
        }

        [Fact]
        public void Validar_BirthDateNaoPreenchido_Ex_test()
        {
            //Setup
            var person = GenerateEntity.GenerateExamplePerson(null
                                                              , null
                                                              , DateTime.MinValue
                                                              , null);

            //Fact
            ValidationException ex = Assert.Throws<ValidationException>(() => app.Validar(person));

            //Assert
            Assert.Equal("GetNameRequired", ex.Erros[0]);
        }

        [Fact]
        public void Validar_Sucesso_test()
        {
            //Setup
            var person = GenerateEntity.GenerateExamplePerson(null
                                                              , null
                                                              , null
                                                              , null);

            //Fact
            app.Validar(person);

            //Assert
        }
    }
}
