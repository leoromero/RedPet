using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedPet.Common.Auth.Models
{
    public class JwtModel
    {
        public string UserName { get; set; }
        public string AuthToken { get; set; }
        public string RefreshToken { get; set; }
        public int ExpiresIn { get; set; }
    }
}
