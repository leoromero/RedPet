using System;
using System.Collections.Generic;

namespace RedPet.Database.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public virtual IList<Pet> Pets { get; internal set; }
    }
}