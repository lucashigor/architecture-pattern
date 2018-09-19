using Domain;
using System.Collections.Generic;

namespace Business
{
    public interface IExamplePersonBusiness
    {
        ExamplePerson SavePerson(ExamplePerson person);

        ICollection<ExamplePerson> GetCollection();

        void Delete(ExamplePerson person);

        void Delete(int id);

        ExamplePerson Get(int Id);

        ExamplePerson UpdatePerson(ExamplePerson person);
    }
}
