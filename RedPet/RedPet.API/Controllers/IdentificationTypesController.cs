using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RedPet.API.Extensions;
using RedPet.Common.Models.Pet;
using RedPet.Common.Models.Provider;
using RedPet.Core;

namespace RedPetAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiVersion("1")]
    [Authorize]
    public class IdentificationTypesController : Controller
    {
        private readonly IIdentificationTypeService identificationTypeService;

        public IdentificationTypesController(IIdentificationTypeService identificationTypeService )
        {
            this.identificationTypeService = identificationTypeService;
        }
        
        [HttpGet]
        public async Task<ActionResult<List<IdentificationTypeModel>>> GetAsync()
        {
            var result = await identificationTypeService.GetAsync();
            return result.ConvertToActionResult(System.Net.HttpStatusCode.OK);
        }
    }
}
