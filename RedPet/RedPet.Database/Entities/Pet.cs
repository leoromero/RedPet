using System;
using System.Collections.Generic;

namespace RedPet.Database.Entities
{
    public class Pet : BaseEntity
    {
        public string Name { get; set; }
        public char Gender { get; set; }
        public bool Sterilized { get; set; }
        public string Observations { get; set; }
        public DateTime BirthDate { get; set; }
        public int MealsPerDay { get; set; }
        public string PreferedFood { get; set; }
        public bool VaccinesUpToDate { get; set; }

        public int? BreedId { get; set; }
        public int? PetSizeId { get; set; }
        public int? WeightRangeId { get; set; }
        public int OwnerId { get; set; }
        public int? VetId { get; set; }

        public virtual Breed Breed { get; set; }
        public virtual PetSize PetSize { get; set; }
        public virtual WeightRange WeightRange { get; set; }
        public virtual Customer Owner { get; set; }
        public virtual Vet Vet{ get; set; }

    }
}