using RedPet.Common.Models.Base;

namespace RedPet.Common.Models.Pet
{
    public class WeightRangeModel : IViewModel, ICreateModel, IUpdateModel
    {
        public int? From { get; set; }
        public int? To { get; set; }
        public int? Id { get; set; }
    }
}