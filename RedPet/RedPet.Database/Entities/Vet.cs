using System;

namespace RedPet.Database.Entities
{
    public class Vet : BaseEntity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }
}