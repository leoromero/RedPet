using RedPet.Common.Models.Base;

namespace RedPet.Common.Models.Pet
{
    public class BreedModel : IViewModel, ICreateModel, IUpdateModel
    {
        public string Name { get; set; }
        public PetSizeModel PetSize { get; set; }
        public HairTypeModel HairType { get; set; }
        public int? Id { get; set; }
        public int? PetSizeId { get; set; }
        public int? HairTypeId { get; set; }
    }
}