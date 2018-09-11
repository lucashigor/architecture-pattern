using System;

namespace Tier.Entities
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDay {
            get { return DateTime.Parse(birth); }
            set { birth = value.ToString(); }
        }
        public string birth { get; set; }
        public string Cpf { get; set; }
    }
}
