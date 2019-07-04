using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RedPet.API.Extensions;
using RedPet.Common.Models.Provider;
using RedPet.Core;

namespace RedPetAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiVersion("1")]
    [Authorize]
    public class NationalitiesController : Controller
    {
        private readonly INationalityService nationalityService;

        public NationalitiesController(INationalityService nationalityService)
        {
            this.nationalityService = nationalityService;
        }
        
        [HttpGet]
        public async Task<ActionResult<List<NationalityModel>>> GetAsync()
        {
            var result = await nationalityService.GetAsync();
            return result.ConvertToActionResult(System.Net.HttpStatusCode.OK);
        }
    }
}
