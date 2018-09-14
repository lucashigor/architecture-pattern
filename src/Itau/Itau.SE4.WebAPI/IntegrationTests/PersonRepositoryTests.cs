using Itau.SE4.Entities;
using Itau.SE4.Repository;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using Xunit;

namespace IntegrationTests
{
    public class PersonRepositoryTests
    {
        protected Mock<IContextFactory> _fabrica;
        protected SE4Context _context;

        [Fact]
        public void CreatePersonOnRepository()
        {
            //
            var options = new DbContextOptionsBuilder<SE4Context>()
                .UseInMemoryDatabase(databaseName: "Add_writes_to_database")
                .Options;

            _fabrica = new Mock<IContextFactory>();

            _context = new SE4Context(options);

            _fabrica.Setup(x => x.GetContext()).Returns(_context);

            var app = new ExamplePersonRepository(_fabrica.Object);
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
            var ret = app.GetByCpf(cpf);

            Assert.Equal(cpf, ret.Cpf);
        }

        [Fact]
        public void DeletePersonOnRepository()
        {
            //
            var options = new DbContextOptionsBuilder<SE4Context>()
                .UseInMemoryDatabase(databaseName: "Add_writes_to_database")
                .Options;

            _fabrica = new Mock<IContextFactory>();

            _context = new SE4Context(options);

            _fabrica.Setup(x => x.GetContext()).Returns(_context);

            var app = new ExamplePersonRepository(_fabrica.Object);
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
