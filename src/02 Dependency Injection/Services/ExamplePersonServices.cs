using System.Collections.Generic;
using Business;
using Domain;

namespace Services
{
    public class ExamplePersonServices : IExamplePersonServices
    {
        private readonly IExamplePersonBusiness _examplePersonBusiness;

        public ExamplePersonServices(IExamplePersonBusiness examplePersonBusiness)
        {
            _examplePersonBusiness = examplePersonBusiness;
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
            return _examplePersonBusiness.SavePerson(person);
        }

        public ExamplePerson UpdatePerson(ExamplePerson person)
        {
            return _examplePersonBusiness.UpdatePerson(person);
        }
    }
}
