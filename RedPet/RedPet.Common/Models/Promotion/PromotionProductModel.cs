using System;
using RedPet.Common.Models.Base;
using RedPet.Common.Models.Product;

namespace RedPet.Common.Models.Promotion
{
    public class PromotionProductModel : IViewModel, ICreateModel, IUpdateModel
    {
        public ProductModel Product { get; set; }
        public PromotionModel Promotion { get; set; }
        public int ProductId { get; set; }
        public int PromotionId { get; set; }
    }
}
