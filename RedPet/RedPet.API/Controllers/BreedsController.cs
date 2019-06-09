using System.Collections.Generic;
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
    public class BreedsController : Controller
    {
        private readonly IBreedService breedService;

        public BreedsController(IBreedService breedService )
        {           
            this.breedService = breedService;
        }
               
        [HttpGet]
        public async Task<ActionResult<List<BreedModel>>> GetAsync()
        {
            var result = await breedService.GetAsync();
            return result.ConvertToActionResult(System.Net.HttpStatusCode.OK);
        }
    }
}
