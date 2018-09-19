using App.Controllers;
using Domain;
using Kernel;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Moq;
using Services;
using System;
using System.Linq;
using Xunit;
using Xunit.Gherkin.Quick;

namespace ComponentsTests
{
    [FeatureFile("./Addition/PersonControllerTests.feature")]
    public sealed partial class PersonControllerTests : Feature
    {
        private ExamplePerson _examplePerson;
        private PersonController _personController;
        private Mock<ILogger<PersonController>> _log;

        public PersonControllerTests()
        {
            IServiceCollection serviceCollection = new ServiceCollection();

            Boostraper.Configure(serviceCollection);
            var serviceProvider = serviceCollection.BuildServiceProvider();

            _log = new Mock<ILogger<PersonController>>();

            _personController = new PersonController(serviceProvider.GetService<IExamplePersonServices>(), _log.Object);

            _examplePerson = new ExamplePerson();
        }

        [Given(@"Que eu possua um participante com os seguintes dados:")]
        [When(@"Que eu possua um participante com os seguintes dados:")]
        public void Que_eu_possua_um_participante_com_os_seguintes_dados(Gherkin.Ast.DataTable dataTable)
        {
            foreach (var row in dataTable.Rows.Skip(1))
            {
                _examplePerson.Name = row.Cells.ElementAt(1).Value.ToString();
                _examplePerson.Cpf = row.Cells.ElementAt(2).Value.ToString();
                _examplePerson.BirthDate = DateTime.Parse(row.Cells.ElementAt(2).Value.ToString());
            }
        }

        [Given(@"Eu Envio uma Requisição Post para a PersonControler")]
        [When(@"Eu Envio uma Requisição Post para a PersonControler")]
        public void Eu_envio_uma_requisicao_post_para_personControler()
        {
            _personController.Post(_examplePerson);
        }
        
        [Then(@"O participante deve possuir um Id")]
        public void O_participate_deve_possuir_um_id()
        {
            Assert.NotEqual(0,_examplePerson.Id);
        }
    }
}
