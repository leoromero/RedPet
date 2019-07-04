using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RedPet.API.Extensions;
using RedPet.Common.Models.Pet;
using RedPet.Core;

namespace RedPetAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiVersion("1")]
    [Authorize]
    public class PetsController : Controller
    {
        private readonly IPetService petService;

        public PetsController(IPetService petService)
        {
            this.petService = petService;
        }

        [HttpGet("{petId}")]
        public async Task<ActionResult<PetModel>> GetAsync(int petId)
        {
            var result = await petService.GetAsync(petId);
            return result.ConvertToActionResult(System.Net.HttpStatusCode.OK);
        }

        [HttpPost]
        public async Task<ActionResult<int>> PostAsync([FromBody] PetCreateUpdateModel model)
        {
            model.OwnerId = User.GetUserId();

            var result = await petService.CreateAsync(model);
            return result.ConvertToActionResult(System.Net.HttpStatusCode.OK);
        }

        [HttpPut("{petId}")]
        public async Task<ActionResult<PetModel>> PutAsync(int petId, [FromBody] PetCreateUpdateModel model)
        {
           // model.OwnerId = User.GetUserId();

            var result = await petService.UpdateAsync(petId, model);
            return result.ConvertToActionResult(System.Net.HttpStatusCode.OK);
        }
    }
}
