using System.Collections.Generic;

namespace RedPet.Database.Entities
{
    public class PromotionService : BaseEntity
    {
        public virtual Service Service{ get; set; }
        public virtual Promotion Promotion { get; set; }
        public int ServiceId { get; set; }
        public int PromotionId { get; set; }
    }
}