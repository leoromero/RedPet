using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace RedPet.Database.Entities.Identity
{
    public class User : IdentityUser<int>, IBaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public IEnumerable<IdentityRole<int>> Roles { get; set; }
        public long FacebookId { get; set; }
        public DateTime? InactivationDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public string RefreshToken { get; set; }

        public string Role { get; set; }
    }
}