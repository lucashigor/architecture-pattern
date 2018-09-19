using Domain;
using System;
using System.Collections.Generic;

namespace Repository
{
    public class ExamplePersonRepository : IExamplePersonRepository
    {
        public ExamplePerson GetByCpf(string cpf)
        {
            return new ExamplePerson() {
                Id = 1,
                Name = "Lucas Higor",
                Cpf = "425680428",
                BirthDate = DateTime.Today
            };
        }

        public void DeleteByCpf(string cpf)
        {
        }

        public void Delete(int Id)
        {
        }

        public ExamplePerson Create(ExamplePerson examplePerson)
        {
            examplePerson.Id = 1;
            return examplePerson;
        }

        public ExamplePerson Update(ExamplePerson person)
        {
            return person;
        }

        public ICollection<ExamplePerson> GetAll()
        {
            var a = new ExamplePerson()
            {
                Id = 1,
                Name = "Lucas Higor",
                Cpf = "425680428",
                BirthDate = DateTime.Today
            };

            var b = new List<ExamplePerson>();

            b.Add(a);

            return b;
        }

        public ExamplePerson GetById(int Id)
        {
            return new ExamplePerson()
            {
                Id = 1,
                Name = "Lucas Higor",
                Cpf = "425680428",
                BirthDate = DateTime.Today
            };
        }
    }
}
