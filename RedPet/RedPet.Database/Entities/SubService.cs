using System;
using System.Collections.Generic;
using System.Text;

namespace RedPet.Database.Entities
{
    public class SubService : BaseEntity
    {
        public string Name { get; set; }
        public int ServiceTypeId { get; set; }

        public virtual ServiceType ServiceType { get; set; }
    }
}
