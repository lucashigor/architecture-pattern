using System;
using System.ComponentModel.DataAnnotations;

namespace EntityPhoto
{
    public class Address
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(250)]
        public string StreetName { get; set; }

        public DateTime LiberatedTime { get; set; }
    }
}