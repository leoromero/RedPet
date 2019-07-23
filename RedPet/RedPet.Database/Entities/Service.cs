using System.Collections.Generic;

namespace RedPet.Database.Entities
{
    public class Service : BaseEntity
    {
        public int ServiceTypeId { get; set; }
        public int ProviderId { get; set; }
        public int WeekDaysId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        
        public virtual ServiceType ServiceType { get; set; }
        public virtual Provider Provider { get; set; }        
        public virtual WeekDays WeekDays { get; set; }

        public virtual IList<ServiceFrecuency> ServiceFrecuencies { get; set; }
        public virtual IList<ServicePetSize> ServicePetSizes { get; set; }
        public virtual IList<ServiceSubService> ServiceSubServices { get; set; }
    }
}
