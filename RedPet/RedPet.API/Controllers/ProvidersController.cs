using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RedPet.API.Extensions;
using RedPet.Common.Models.Provider;
using RedPet.Common.Models.Service;
using RedPet.Core;

namespace RedPetAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiVersion("1")]
    [Authorize]
    public class ProvidersController : Controller
    {
        private readonly IProviderService providerService;

        public ProvidersController(IProviderService providerService)
        {
            this.providerService = providerService;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<int>> Post([FromBody] ProviderCreateUpdateModel model)
        {
            var result = await providerService.CreateAsync(model);

            return result.ConvertToActionResult(HttpStatusCode.Created);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<ProviderModel>> Put(int id, [FromBody] ProviderCreateUpdateModel model)
        {
            var result = await providerService.UpdateAsync(id, model);

            return result.ConvertToActionResult(HttpStatusCode.Created);
        }

        [HttpGet]
        public async Task<ActionResult<List<ProviderModel>>> GetAsync()
        {
            var result = await providerService.GetAsync();
            return result.ConvertToActionResult(HttpStatusCode.OK);
        }

        [HttpGet("{userName}")]
        public async Task<ActionResult<ProviderModel>> GetAsync(string userName)
        {
            var result = await providerService.GetByEmailAsync(userName);
            return result.ConvertToActionResult(HttpStatusCode.OK);
        }

        [HttpGet("{userId}/Services")]
        public async Task<ActionResult<List<ServiceModel>>> GetServicesAsync(int userId)
        {
            var loggedUserId = User.FindFirst("Id");
            var loggedUserRole = User.FindFirst("Role");
            if (User.IsInRole("Provider") && loggedUserId.Value != userId.ToString())
                return BadRequest();

            var result = await providerService.GetServicesAsync(userId);
            return result.ConvertToActionResult(HttpStatusCode.OK);
        }
    }
}
