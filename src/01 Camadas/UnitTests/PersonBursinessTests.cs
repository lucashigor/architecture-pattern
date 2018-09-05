using System;
using Tier.Business;
using Tier.Common;
using Tier.Entities;
using Xunit;

namespace UnitTests
{
    public class PersonBursinessTests
    {
        [Fact]
        public void ValidateMaxAge_ParticipanteDentroDaIdade_test()
        {
            var app = new PersonBusiness();

            var person = new Person()
            {
                Name = "Usuario 1",
                BirthDay = DateTime.Today.AddYears(-(Parameters.max_age - 1))
            };

            app.ValidateMaxAge(person);
        }

        [Fact]
        public void ValidateAdvancedAge_ParticipanteDentroDaIdade_test()
        {
            var app = new PersonBusiness();

            var person = new Person()
            {
                Name = "Usuario 1",
                BirthDay = DateTime.Today.AddYears(-(Parameters.warning_max_age - 1))
            };

            app.ValidateAdvancedAge(person);
        }

        [Fact]
        public void ValidateMaxAge_ParticipanteForaDaIdade_test()
        {
            var app = new PersonBusiness();

            var person = new Person()
            {
                Name = "Usuario 1",
                BirthDay = DateTime.Today.AddYears(-(Parameters.max_age + 1))
            };

            BusinessException ex = Assert.Throws<BusinessException>(() => app.ValidateMaxAge(person));

            Assert.Equal(ExceptionsMessages.IDADE_NAO_PERMITIDA, ex.Message);

        }

        [Fact]
        public void ValidateAvancedAge_ParticipanteDentroDaIdade_test()
        {
            var app = new PersonBusiness();

            var person = new Person()
            {
                Name = "Usuario 1",
                BirthDay = DateTime.Today.AddYears(-(Parameters.warning_max_age + 1))
            };

            BusinessException ex = Assert.Throws<BusinessException>(() => app.ValidateAdvancedAge(person));

            Assert.Equal(ExceptionsMessages.IDADE_AVANCADA, ex.Message);
            Assert.Equal((int)EnumExceptionLevel.ExceptionLevel.Warning, ex.Level);
        }
    }
}
