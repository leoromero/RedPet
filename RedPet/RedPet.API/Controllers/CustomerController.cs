using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RedPet.API.Extensions;
using RedPet.Common.Models.Pet;
using RedPet.Common.Models.User;
using RedPet.Core;

namespace RedPetAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiVersion("1")]
    [Authorize]
    public class CustomerController : Controller
    {
        private readonly ICustomerService userService;

        public CustomerController(ICustomerService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<List<CustomerModel>>> GetAsync()
        {
            var result = await userService.GetAsync();
            return result.ConvertToActionResult(System.Net.HttpStatusCode.OK);
        }

        [HttpGet("Pets")]
        public async Task<ActionResult<List<PetModel>>> GetPetsAsync()
        {
            var userName = User.Identity.Name;
            var result = await userService.GetPetsAsync(userName);
            return result.ConvertToActionResult(System.Net.HttpStatusCode.OK);
        }
    }
}
