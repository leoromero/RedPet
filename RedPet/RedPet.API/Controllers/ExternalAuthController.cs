using Microsoft.AspNetCore.Mvc;
using RedPet.API.Extensions;
using RedPet.Common.Auth.Models;
using RedPet.Core.Auth;
using System.Net;
using System.Threading.Tasks;

namespace RedPet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiVersion("1")]
    public class ExternalAuthController : Controller
    {
        private readonly IAuthService authService;

        public ExternalAuthController(IAuthService authService)
        {
            this.authService = authService;
        }
        // POST api/externalauth/facebook
        [HttpPost]
        public async Task<ActionResult<string>> Facebook([FromBody]FacebookAuthViewModel model)
        {
            var response = await authService.GenerateJwtFromFacebookAsync(model);
            return response.ConvertToActionResult(HttpStatusCode.OK);
        }
    }
}
