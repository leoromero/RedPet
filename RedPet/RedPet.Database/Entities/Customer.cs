using RedPet.Database.Entities.Identity;
using System.Collections.Generic;

namespace RedPet.Database.Entities
{
    public class Customer : BaseEntity
    {
        public string Address { get; set; }
        public virtual IList<Pet> Pets { get; internal set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}