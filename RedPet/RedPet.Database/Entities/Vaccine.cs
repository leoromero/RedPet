using System;

namespace RedPet.Database.Entities
{
    public class Vaccine : BaseEntity
    {
        public string Name { get; set; }
        public string Info { get; set; }
    }
}