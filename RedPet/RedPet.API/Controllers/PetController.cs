using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RedPet.API.Extensions;
using RedPet.Common.Models.Pet;
using RedPet.Core;

namespace RedPetAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiVersion("1")]
    public class PetController : Controller
    {
        private readonly IPetService petService;

        public PetController(IPetService petService)
        {
            this.petService = petService;
        }

        [HttpGet]
        public async Task<ActionResult<List<PetModel>>> GetAsync()
        {
            var result = await petService.GetAsync();
            return result.ConvertToActionResult(System.Net.HttpStatusCode.OK);
        }

        [HttpPost]
        public async Task<ActionResult<int>> PostAsync([FromBody] PetCreateUpdateModel model)
        {
            var result = await petService.CreateAsync(model);
            return result.ConvertToActionResult(System.Net.HttpStatusCode.OK);
        }

        [HttpPut("{petId}")]
        public async Task<ActionResult> PutAsync(int petId, [FromBody] PetCreateUpdateModel model)
        {
            await petService.UpdateAsync(petId, model);
            return Ok();
        }
    }
}
