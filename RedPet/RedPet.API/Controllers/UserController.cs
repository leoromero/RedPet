using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RedPet.API.Extensions;
using RedPet.Common.Models.Pet;
using RedPet.Common.Models.User;
using RedPet.Core;

namespace RedPetAPI.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly ICustomerService userService;

        public UserController(ICustomerService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerModel>>> GetAsync()
        {
            var result = await userService.GetAsync();
            return result.ConvertToActionResult(System.Net.HttpStatusCode.OK);
        }

        [HttpGet("Pets/{userId}")]
        public async Task<ActionResult<IEnumerable<PetModel>>> GetPetsAsync(int userId)
        {
            var result = await userService.GetPetsAsync(userId);
            return result.ConvertToActionResult(System.Net.HttpStatusCode.OK);
        }
    }
}
