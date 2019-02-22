using RedPet.Common.Models.Base;
using RedPet.Common.Models.Service;

namespace RedPet.Common.Models.Promotion
{
    public class PromotionServiceModel : IViewModel, ICreateModel, IUpdateModel
    {
        public ServiceModel Service { get; set; }
        public PromotionModel Promotion { get; set; }
        public int? ServiceId { get; set; }
        public int? PromotionId { get; set; }
    }
}
