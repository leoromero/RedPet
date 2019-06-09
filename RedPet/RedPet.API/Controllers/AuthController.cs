using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RedPet.API.Extensions;
using RedPet.Common.Auth.Models;
using RedPet.Common.Models.Auth;
using RedPet.Core.Auth;
using System.Net;
using System.Threading.Tasks;

namespace RedPet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiVersion("1")]
    public class AuthController : Controller
    {
        private readonly IAuthService authService;

        public AuthController(IAuthService authService)
        {
            this.authService = authService;
        }

        [HttpPost("Refresh")]
        [AllowAnonymous]
        public async Task<ActionResult<JwtModel>> Refresh([FromBody] RefreshTokenModel model)
        {
            var result = await authService.RefreshTokenAsync(model);
            return result.ConvertToActionResult(HttpStatusCode.OK);
        }
    }
}
