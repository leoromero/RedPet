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
    public class WeightRangesController : Controller
    {
        private readonly IWeightRangeService weightRangeService;

        public WeightRangesController(IWeightRangeService weightRangeService )
        {
            this.weightRangeService = weightRangeService;
        }

        [HttpGet]
        public async Task<ActionResult<List<WeightRangeModel>>> GetAsync()
        {
            var result = await weightRangeService.GetAsync();
            return result.ConvertToActionResult(System.Net.HttpStatusCode.OK);
        }
    }
}
