using System;

namespace RedPet.Database.Entities
{
    public class Vaccination : BaseEntity
    {
        public int PetId { get; set; }
        public int VaccineId { get; set; }
        public DateTime VacinationDate { get; set; }

        public virtual Vaccine Vaccine { get; set; }
        public virtual Pet Pet { get; set; }
    }
}