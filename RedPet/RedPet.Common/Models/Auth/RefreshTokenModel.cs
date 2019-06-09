using System;
using System.Collections.Generic;
using System.Text;

namespace RedPet.Common.Models.Auth
{
    public class RefreshTokenModel
    {
        public string RefreshToken { get; set; }
        public string AuthToken { get; set; }
    }
}
