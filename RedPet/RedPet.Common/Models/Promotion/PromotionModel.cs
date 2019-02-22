using System;
using System.Collections.Generic;
using RedPet.Common.Models.Base;
using RedPet.Common.Models.Product;
using RedPet.Common.Models.Service;

namespace RedPet.Common.Models.Promotion
{
    public class PromotionModel : IViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Discount { get; set; }
        public decimal Price { get; set; }
        public decimal Taxes { get; set; }

        public IList<ServiceModel> PromotionServices { get; set; }
        public IList<ProductModel> PromotionProducts { get; set; }
        public AudienceModel Audience { get; set; }
    }

    public class PromotionCreateUpdateModel : ICreateModel, IUpdateModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Discount { get; set; }
        public decimal Price { get; set; }
        public decimal Taxes { get; set; }

        public IList<ServiceModel> PromotionServices { get; set; }
        public IList<ProductModel> PromotionProducts { get; set; }
        public AudienceCreateUpdateModel Audience { get; set; }
    }

}
