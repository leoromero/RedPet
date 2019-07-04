using System;
using System.Collections.Generic;
using System.Text;

namespace RedPet.Database.Entities
{
    public class ServiceType : BaseEntity
    {
        public string Name { get; set; }

        public virtual IList<SubService> SubServices { get; set; }
    }
}
