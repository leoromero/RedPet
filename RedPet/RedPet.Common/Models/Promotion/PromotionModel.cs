using System;
using RedPet.Common.Models.Base;

namespace RedPet.Common.Models.Promotion
{
    public class PromotionModel : IViewModel, ICreateModel, IUpdateModel
    {
        public string Description { get; set; }
        public string Name { get; set; }
        public long Id { get; set; }
    }
}
