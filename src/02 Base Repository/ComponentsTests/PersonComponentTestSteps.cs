using System;
using System.Linq;
using SimpleInjector;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Tier.Common;
using Tier.Entities;
using Tier.Service;
using Tiers.Web.Controllers;

namespace ComponentsTests
{
    [Binding]
    public class PersonComponentTestSteps
    { 
        Person person;

        Container container;

        Object ret;

        PersonController app;

        public PersonComponentTestSteps()
        {
            container = new Container();

            Bootstrapper.Configure(container);

            app = new PersonController(container.GetInstance<IPersonService>());
        }

        [Given(@"Eu tenha inserido um participante com mais idade não permitida:")]
        public void DadoEuTenhaInseridoUmParticipanteComMaisIdadeNaoPermitida(Table table)
        {
            person = table.CreateSet<Person>().First();

            person.BirthDay = DateTime.Today.AddYears(-(Parameters.max_age + 1));
        }

        [When(@"Eu envio Post")]
        public void QuandoEuEnvioPost()
        {
            try
            {
                app.Post(person);
            }
            catch (Exception ex)
            {
                ret = ex;
            }
        }

        [Then(@"Um erro deve ocorrer")]
        public void EntaoUmErroDeveOcorrer()
        {
            var retorno = (BusinessException)ret;
        }       

        [Given(@"Que tenha um participante na base com idade valida:")]
        public void DadoQueTenhaUmParticipanteNaBaseComIdadeValida(Table table)
        {
            person = table.CreateSet<Person>().First();

            person.BirthDay = DateTime.Today.AddYears(-(Parameters.warning_max_age - 1));

            app.Post(person);
        }

        [When(@"Eu envio o Delete")]
        public void QuandoEuEnvioODelete()
        {
            app.Delete(person);
        }

        [Then(@"A base deve ficar vazia")]
        public void EntaoABaseDeveFicarVazia()
        {
            var a  = app.Get(person.Id);
        }
    }
}