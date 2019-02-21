using System;
using RedPet.Common.Models.Base;
using RedPet.Common.Models.User;

namespace RedPet.Common.Models.Pet
{
    public class PetModel : IViewModel
    {
        public string Name { get; set; }
        public BreedModel Breed { get; set; }
        public PetSizeModel Size { get; set; }
        public HairTypeModel HairType { get; set; }
        public WeightRangeModel Weight { get; set; }
        public DateTime BirthDate { get; set; }
        public char Gender { get; set; }
        public bool Sterilized { get; set; }
        public string Observations { get; set; }
        public CustomerModel Owner { get; set; }
    }

    public class PetCreateUpdateModel : ICreateModel, IUpdateModel
    {
        public string Name { get; set; }
        public int BreedId { get; set; }
        public int SizeId { get; set; }
        public int HairTypeId { get; set; }
        public int WeightRangeId { get; set; }
        public DateTime BirthDate { get; set; }
        public char Gender { get; set; }
        public bool Sterilized { get; set; }
        public string Observations { get; set; }
        public int OwnerId { get; set; }
    }
}
