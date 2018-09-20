using Microsoft.Extensions.DependencyInjection;
using Repository;
using TestsCommons;
using Xunit;

namespace IntegrationTests
{
    public class PersonRepositoryTests : TesteBase
    {
        protected ExamplePersonRepository app;

        public PersonRepositoryTests()
        {
            app = new ExamplePersonRepository(serviceProvider.GetService<IContextFactory>());
        }

        [Fact]
        public void CreatePersonOnRepository()
        {
            //Setup
            var person = GenerateEntity.GenerateExamplePerson( null
                                                             , null
                                                             , null
                                                             , null);

            //fact
            app.Create(person);

            //Assert
            Assert.NotEqual(0, person.Id);
            app.Delete(person);
        }

        [Fact]
        public void DeletePersonOnRepository()
        {
            //Setup
            var cpf = "121.230.200-11";

            var person = GenerateEntity.GenerateExamplePerson(null
                                                             , null
                                                             , null
                                                             , cpf);

            app.Create(person);

            //fact

            app.Delete(person);

            var ret = app.GetByCpf(cpf);

            Assert.Null(ret);
        }
    }
}
