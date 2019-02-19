using System.Collections.Generic;

namespace RedPet.Database.Entities
{
    public class PromotionProduct : BaseEntity
    {
        public virtual Product Product { get; set; }
        public virtual Promotion Promotion { get; set; }
        public int ProductId { get; set; }
        public int PromotionId { get; set; }
    }
}