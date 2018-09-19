using Domain;
using System.Collections.Generic;

namespace Repository
{
    public interface IExamplePersonRepository
    {
        ExamplePerson Create(ExamplePerson examplePerson);

        ExamplePerson GetByCpf(string cpf);

        void DeleteByCpf(string cpf);

        void Delete(int Id);

        ExamplePerson Update(ExamplePerson person);

        ICollection<ExamplePerson> GetAll();

        ExamplePerson GetById(int Id);
    }
}
