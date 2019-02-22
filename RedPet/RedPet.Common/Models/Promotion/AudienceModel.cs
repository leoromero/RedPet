using System;
using RedPet.Common.Models.Base;
using RedPet.Common.Models.Pet;

namespace RedPet.Common.Models.Promotion
{
    public class AudienceModel : IViewModel, ICreateModel, IUpdateModel
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public PetSizeModel PetSize { get; set; }
        public BreedModel Breed { get; set; }
        public WeightRangeModel WeightRange { get; set; }

        public int? PetSizeId { get; set; }
        public int? BreedId { get; set; }
        public int? WeightRangeId { get; set; }
    }
}
