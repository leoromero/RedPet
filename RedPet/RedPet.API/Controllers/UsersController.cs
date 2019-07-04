using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RedPet.API.Extensions;
using RedPet.Common.Auth.Models;
using RedPet.Common.Models.User;
using RedPet.Core;
using System.Net;
using System.Threading.Tasks;

namespace RedPetAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiVersion("1")]
    [Authorize]
    public class UsersController : Controller
    {
        private readonly IUserService userService;
        private readonly ICustomerService customerService;

        public UsersController(IUserService userService, ICustomerService customerService)
        {
            this.userService = userService;
            this.customerService = customerService;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] UserCreateUpdateModel model)
        {
            var result = await userService.CreateUserAsync(model);

            return result.ConvertToActionResult(HttpStatusCode.Created);
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<UserModel>> Get([FromRoute] int id)
        {
            var result = await userService.GetAsync(id);
            return result.ConvertToActionResult(HttpStatusCode.OK);
        }

        [HttpHead("Email/{email}")]
        [AllowAnonymous]
        public async Task<ActionResult<EmailModel>> GetEmail([FromRoute] string email)
        {
            var result = await userService.ValidateEmailAsync(email);
            return result.ConvertToActionResult(HttpStatusCode.OK);
        }
    }
}
