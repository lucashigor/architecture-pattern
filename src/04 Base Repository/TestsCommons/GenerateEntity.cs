using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestsCommons
{
    public static class GenerateEntity
    {
        public static ExamplePerson GenerateExamplePerson(int? id, string name, DateTime? birthdate, string cpf)
        {
            var _id = id ?? 0;
            var _name = name ?? "Participante 1";
            var _birthdate = birthdate ?? DateTime.Today.AddYears(-10);
            var _cpf = cpf ?? "12123020010";

            return new ExamplePerson()
            {
                Id = _id,
                Name = _name,
                BirthDate = _birthdate,
                Cpf = _cpf 
            };
        }
    }
}
