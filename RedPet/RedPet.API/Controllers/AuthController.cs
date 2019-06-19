using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RedPet.API.Extensions;
using RedPet.Common.Auth.Models;
using RedPet.Common.Models.Auth;
using RedPet.Common.Models.User;
using RedPet.Core;
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
        private readonly IUserService userService;

        public AuthController(IAuthService authService, IUserService userService)
        {
            this.authService = authService;
            this.userService = userService;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<JwtModel>> Post([FromBody] LoginModel model)
        {
            var result = await authService.LoginAsync(model);
            return result.ConvertToActionResult(HttpStatusCode.OK);
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
