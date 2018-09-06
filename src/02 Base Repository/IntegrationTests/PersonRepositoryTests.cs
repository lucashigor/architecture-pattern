using Effort;
using Moq;
using System;
using Tier.Entities;
using Tier.Repository;
using Xunit;

namespace IntegrationTests
{
    public class PersonRepositoryTests
    {

        protected Mock<IFactoryBase> _fabrica;
        protected Context _context;

        [Fact]
        public void TestMethod1()
        {
            _fabrica = new Mock<IFactoryBase>();

            var conn = DbConnectionFactory.CreateTransient();

            _context = new Context(conn);

            _fabrica.Setup(x => x.GetContext()).Returns(_context);


            var app = new PersonRepository(_fabrica.Object);
            var cpf = "121.230.200-10";

            var person = new Person()
            {
                Name = "Usuario 1",
                BirthDay = DateTime.Today,
                Cpf = cpf
            };

            app.Create(person);
          

            var ret = app.GetByCpf(cpf);

            Assert.Equal(cpf, ret.Cpf);
        }
    }
}
