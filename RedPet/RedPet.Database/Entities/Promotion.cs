using System.Collections.Generic;

namespace RedPet.Database.Entities
{
    public class Promotion : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Discount { get; set; }
        public decimal Price { get; set; }
        public decimal Taxes { get; set; }

        public virtual IList<PromotionService> PromotionServices { get; set; }
        public virtual IList<PromotionProduct> PromotionProducts { get; set; }


        public virtual Audience Audience { get; set; }

        public int AudienceId { get; set; }    }
}