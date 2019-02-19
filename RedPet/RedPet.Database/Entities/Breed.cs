using System;
using System.Collections.Generic;
using System.Text;

namespace RedPet.Database.Entities
{
    public class Breed : BaseEntity
    {
        public string Name { get; set; }
        public virtual PetSize PetSize { get; set; }
        public virtual HairType HairType { get; set; }
        public int? PetSizeId { get; set; }
        public int? HairTypeId { get; set; }
    }
}
