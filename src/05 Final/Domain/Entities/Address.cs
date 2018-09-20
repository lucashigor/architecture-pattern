using System;

namespace Domain
{
    public class Address
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string StreetName { get; set; }

        public DateTime LiberatedTime { get; set; }
    }
}