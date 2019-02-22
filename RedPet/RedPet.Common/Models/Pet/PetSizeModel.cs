using RedPet.Common.Models.Base;

namespace RedPet.Common.Models.Pet
{
    public class PetSizeModel : IViewModel, ICreateModel, IUpdateModel
    {
        public string Name { get; set; }
        public WeightRangeModel Weight { get; set; }
        public int? Id { get; set; }
    }
}