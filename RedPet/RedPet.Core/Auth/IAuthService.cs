using System.Security.Claims;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RedPet.Common.Auth.Models;
using RedPet.Common.Models.Base;

namespace RedPet.Core.Auth
{
    public interface IAuthService
    {
        string GenerateJwt(ClaimsIdentity identity, string userName, JwtIssuerOptions jwtOptions, JsonSerializerSettings serializerSettings);
        Task<EntityResult<string>> GenerateJwtFromFacebookAsync(FacebookAuthViewModel model);
    }
}