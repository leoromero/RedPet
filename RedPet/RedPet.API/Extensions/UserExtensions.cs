using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RedPet.API.Extensions
{
    public static class UserExtensions
    {
        /// <summary>
        /// Returns the logged user Id, -1 if it couldn't find it.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static int GetUserId(this ClaimsPrincipal user)
        {
            if(int.TryParse(user.FindFirstValue("id"), out var id)) return id;

            return -1;
        }
    }
}
