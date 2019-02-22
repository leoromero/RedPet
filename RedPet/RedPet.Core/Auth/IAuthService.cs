using System.Security.Claims;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RedPet.Common.Auth.Models;
using RedPet.Common.Models.Base;

namespace RedPet.Core.Auth
{
    public interface IAuthService
    {
        JwtModel GenerateJwt(ClaimsIdentity identity, string userName, JwtIssuerOptions jwtOptions, JsonSerializerSettings serializerSettings);
        Task<EntityResult<JwtModel>> GenerateJwtFromFacebookAsync(FacebookAuthViewModel model);
        EntityResult<JwtModel> GenerateGenericJwt();
    }
}