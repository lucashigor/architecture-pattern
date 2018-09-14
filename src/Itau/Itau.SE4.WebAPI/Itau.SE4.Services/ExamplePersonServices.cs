using System.Collections.Generic;
using Itau.SE4.Business;
using Itau.SE4.Domain;

namespace Itau.SE4.Services
{
    public class ExamplePersonServices : IExamplePersonServices
    {
        private readonly IExamplePersonBusiness _examplePersonBusiness;
        private readonly IPersonExampleValidator _personExampleValidator;

        public ExamplePersonServices(IExamplePersonBusiness examplePersonBusiness,
            IPersonExampleValidator personExampleValidator)
        {
            _examplePersonBusiness = examplePersonBusiness;
            _personExampleValidator = personExampleValidator;
        }

        public void Delete(ExamplePerson person)
        {
            _examplePersonBusiness.Delete(person);
        }

        public void Delete(int id)
        {
            _examplePersonBusiness.Delete(id);
        }

        public ExamplePerson Get(int Id)
        {
            return _examplePersonBusiness.Get(Id);
        }

        public ICollection<ExamplePerson> GetCollection()
        {
            return _examplePersonBusiness.GetCollection();
        }

        public ExamplePerson SavePerson(ExamplePerson person)
        {
            _personExampleValidator.Validar(person);
            return _examplePersonBusiness.SavePerson(person);
        }

        public ExamplePerson UpdatePerson(ExamplePerson person)
        {
            return _examplePersonBusiness.UpdatePerson(person);
        }
    }
}
