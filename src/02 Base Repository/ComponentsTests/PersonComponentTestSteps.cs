using SimpleInjector;
using System;
using System.Linq;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Tier.Common;
using Tier.Entities;

namespace ComponentsTests
{
    [Binding]
    public class PersonComponentTestSteps
    {
        Person person;

        Container container;

        [Given(@"Eu tenha inserido um participante com mais de 50 anos:")]
        public void DadoEuTenhaInseridoUmParticipanteComMaisDeAnos(Table table)
        {
            person = table.CreateSet<Person>().First();
        }


        [When(@"Eu envio ocorre um erro")]
        public void QuandoEuEnvioOcorreUmErro()
        {
            Bootstrapper.Configure(container);

            try
            {
                //new PersonController(container.GetInstance<IPersonService>()).Post(person);
            }
            catch (BusinessException)
            {

                throw;
            }
        }

        [Then(@"eh isso ai")]
        public void EntaoEhIssoAi()
        {
            //ScenarioContext.Current.Pending();
        }
    }
}
