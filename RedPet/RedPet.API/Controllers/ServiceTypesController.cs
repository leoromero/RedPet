using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RedPet.API.Extensions;
using RedPet.Common.Models.Pet;
using RedPet.Common.Models.Service;
using RedPet.Core;

namespace RedPetAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiVersion("1")]
    [Authorize]
    public class ServiceTypesController : Controller
    {
        private readonly IServiceTypeService serviceTypeService;

        public ServiceTypesController(IServiceTypeService weightRangeService )
        {
            this.serviceTypeService = weightRangeService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ServiceTypeModel>>> GetAsync()
        {
            var result = await serviceTypeService.GetAsync();
            return result.ConvertToActionResult(System.Net.HttpStatusCode.OK);
        }

        [HttpPost]
        public async Task<ActionResult<int>> PostAsync([FromBody] ServiceTypeModel model)
        {
            var result = await serviceTypeService.CreateAsync(model);
            return result.ConvertToActionResult(System.Net.HttpStatusCode.OK);
        }

        [HttpPut("{serviceTypeId}")]
        public async Task<ActionResult<ServiceTypeModel>> PutAsync(int serviceTypeId, [FromBody] ServiceTypeModel model)
        {
            var result = await serviceTypeService.UpdateAsync(serviceTypeId, model);
            return result.ConvertToActionResult(System.Net.HttpStatusCode.OK);
        }

        [HttpDelete("{serviceTypeId}")]
        public async Task<ActionResult> DeleteAsync(int serviceTypeId)
        {
            await serviceTypeService.DeleteAsync(serviceTypeId);
            return Ok();
        }
    }
}
