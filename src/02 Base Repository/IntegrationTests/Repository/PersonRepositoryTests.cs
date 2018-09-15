using Itau.SE4.Domain;
using Itau.SE4.Repository;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using Xunit;

namespace IntegrationTests
{
    public class PersonRepositoryTests
    {
        protected Mock<IContextFactory> _factory;
        protected SE4Context _context;

        [Fact]
        public void CreatePersonOnRepository()
        {
            //
            var options = new DbContextOptionsBuilder<SE4Context>()
                .UseInMemoryDatabase(databaseName: "Add_writes_to_database")
                .Options;

            _factory = new Mock<IContextFactory>();

            _context = new SE4Context(options);

            _factory.Setup(x => x.GetContext()).Returns(_context);

            var app = new ExamplePersonRepository(_factory.Object);
            var cpf = "121.230.200-10";

            var person = new ExamplePerson()
            {
                Name = "Usuario 1",
                BirthDate = DateTime.Today,
                Cpf = cpf
            };

            //fact
            app.Create(person);

            //Assert
            Assert.NotEqual(0, person.Id);
        }

        [Fact]
        public void DeletePersonOnRepository()
        {
            //
            var options = new DbContextOptionsBuilder<SE4Context>()
                .UseInMemoryDatabase(databaseName: "Add_writes_to_database")
                .Options;

            _factory = new Mock<IContextFactory>();

            _context = new SE4Context(options);

            _factory.Setup(x => x.GetContext()).Returns(_context);

            var app = new ExamplePersonRepository(_factory.Object);
            var cpf = "121.230.200-10";

            var person = new ExamplePerson()
            {
                Name = "Usuario 1",
                BirthDate = DateTime.Today,
                Cpf = cpf
            };

            app.Create(person);

            var ret = app.GetByCpf(cpf);

            Assert.Equal(cpf, ret.Cpf);

            //fact

            app.Delete(ret);

            ret = app.GetByCpf(cpf);

            Assert.Null(ret);
        }
    }
}
