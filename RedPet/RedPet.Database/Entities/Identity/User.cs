using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace RedPet.Database.Entities.Identity
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IEnumerable<IdentityRole> Roles { get; set; }
        public long FacebookId { get; set; }
    }
}