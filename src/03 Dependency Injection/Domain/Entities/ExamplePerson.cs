using System;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class ExamplePerson
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Cpf { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
