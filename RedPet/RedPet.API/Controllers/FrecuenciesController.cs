using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RedPet.API.Extensions;
using RedPet.Common.Models.Service;
using RedPet.Core;

namespace RedPetAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiVersion("1")]
    [Authorize]
    public class FrecuenciesController : Controller
    {
        private readonly IFrecuencyService frecuencyService;

        public FrecuenciesController(IFrecuencyService frecuencyService)
        {
            this.frecuencyService = frecuencyService;
        }
        
        [HttpGet]
        public async Task<ActionResult<List<FrecuencyModel>>> GetAsync()
        {
            var result = await frecuencyService.GetAsync();
            return result.ConvertToActionResult(System.Net.HttpStatusCode.OK);
        }
    }
}
