using System.Security.Claims;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RedPet.Common.Auth.Models;
using RedPet.Common.Models.Auth;
using RedPet.Common.Models.Base;

namespace RedPet.Core.Auth
{
    public interface IAuthService
    {
        Task<EntityResult<JwtModel>> GenerateJwtFromFacebookAsync(FacebookAuthViewModel model);
        Task<EntityResult<JwtModel>> RefreshTokenAsync(RefreshTokenModel model);
        Task<EntityResult<JwtModel>> LoginAsync(LoginModel model);
    }
}