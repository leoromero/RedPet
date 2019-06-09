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
    public class HairTypesController : Controller
    {
        private readonly IHairTypeService hairTypeService;

        public HairTypesController(IHairTypeService hairTypeService )
        {
            this.hairTypeService = hairTypeService;
        }
        
        [HttpGet]
        public async Task<ActionResult<List<HairTypeModel>>> GetAsync()
        {
            var result = await hairTypeService.GetAsync();
            return result.ConvertToActionResult(System.Net.HttpStatusCode.OK);
        }
    }
}
