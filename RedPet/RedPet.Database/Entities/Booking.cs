using System;
using System.Collections.Generic;
using System.Text;

namespace RedPet.Database.Entities
{
    public class Booking : BaseEntity
    {
        public decimal Price { get; set; }
        public decimal Taxes { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime DeliveryDateTime { get; set; }

        public int? ServiceId { get; set; }
        public int? ProductId { get; set; }
        public int? PromotionId { get; set; }
        public int UserId { get; set; }

        public virtual Service Service { get; set; }
        public virtual Product Product { get; set; }
        public virtual Promotion Promotion { get; set; }
        public virtual User User { get; set; }
    }
}
