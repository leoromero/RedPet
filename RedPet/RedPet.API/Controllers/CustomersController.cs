using System.Collections.Generic;
using System.Net;
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
    public class CustomersController : Controller
    {
        private readonly ICustomerService customerService;

        public CustomersController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<int>> Post([FromBody] CustomerCreateUpdateModel model)
        {
            var result = await customerService.CreateAsync(model);

            return result.ConvertToActionResult(HttpStatusCode.Created);
        }

        [HttpGet]
        public async Task<ActionResult<List<CustomerModel>>> GetAsync()
        {
            var result = await customerService.GetAsync();
            return result.ConvertToActionResult(HttpStatusCode.OK);
        }

        [HttpGet("{userName}")]
        public async Task<ActionResult<CustomerModel>> GetAsync(string userName)
        {
            var result = await customerService.GetByEmailAsync(userName);
            return result.ConvertToActionResult(HttpStatusCode.OK);
        }

        [HttpGet("{userId}/Pets")]
        public async Task<ActionResult<List<PetModel>>> GetPetsAsync(int userId)
        {
            var loggedUserId = User.FindFirst("Id");
            var loggedUserRole = User.FindFirst("Role");
            if (User.IsInRole("Customer") && loggedUserId.Value != userId.ToString())
                return BadRequest();

            var result = await customerService.GetPetsAsync(userId);
            return result.ConvertToActionResult(HttpStatusCode.OK);
        }
    }
}
