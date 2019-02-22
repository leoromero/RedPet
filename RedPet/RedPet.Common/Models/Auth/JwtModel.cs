using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedPet.Common.Auth.Models
{
    public class JwtModel
    {
        public string Id { get; set; }
        public string AuthToken { get; set; }
        public int ExpiresIn { get; set; }
    }
}
