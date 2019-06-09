using RedPet.Common.Models.Base;
using System;

namespace RedPet.Common.Models.Pet
{
    public class VaccinationModel : IViewModel, ICreateModel, IUpdateModel
    {
        public int Id { get; set; }
        public int PetId { get; set; }
        public int VaccineId { get; set; }
        public PetModel Pet { get; set; }
        public VaccineModel Vaccine { get; set; }
        public DateTime? VaccinationDate { get; set; }
    }
}