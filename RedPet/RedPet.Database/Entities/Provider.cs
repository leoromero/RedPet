using RedPet.Database.Entities.Identity;
using System.Collections.Generic;

namespace RedPet.Database.Entities
{
    public class Provider : BaseEntity
    {
        public string Address { get; set; } = string.Empty;
        public string Identification { get; set; } = string.Empty;
        public int? NationalityId { get; set; }
        public int? IdentificationTypeId { get; set; }

        public virtual Nationality Nationality{ get; set; }
        public int UserId { get; set; }
        public virtual IdentificationType IdentificationType { get; set; }
        public virtual User User { get; set; }
        public virtual IList<Service> Services { get; internal set; }
    }
}