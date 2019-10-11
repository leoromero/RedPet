using Microsoft.AspNetCore.Mvc;
using RedPet.API.Extensions;
using RedPet.Common.Models.Service;
using RedPet.Core;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RedPetAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiVersion("1")]
    //[Authorize]
    public class ServicesController : Controller
    {
        private readonly IServiceService serviceService;

        public ServicesController(IServiceService serviceService)
        {
            this.serviceService = serviceService;
        }

        [HttpGet("{serviceId}")]
        public async Task<ActionResult<ServiceModel>> GetByIdAsync(int serviceId)
        {
            var result = await serviceService.GetAsync(serviceId);
            return result.ConvertToActionResult(System.Net.HttpStatusCode.OK);
        }

        [HttpPost]
        public async Task<ActionResult<int>> PostAsync([FromBody] ServiceCreateUpdateModel model)
        {
            var result = await serviceService.CreateAsync(model);
            return result.ConvertToActionResult(System.Net.HttpStatusCode.OK);
        }

        [HttpPut("{serviceId}")]
        public async Task<ActionResult<ServiceModel>> PutAsync(int serviceId, [FromBody] ServiceCreateUpdateModel model)
        {
            var result = await serviceService.UpdateAsync(serviceId, model);
            return result.ConvertToActionResult(System.Net.HttpStatusCode.OK);
        }

        [HttpDelete("{serviceId}")]
        public async Task<ActionResult> DeleteAsync(int serviceId)
        {
            await serviceService.DeleteAsync(serviceId);
            return Ok();
        }


        [HttpGet]
        public async Task<ActionResult<List<ServiceModel>>> GetAsync(ServiceSearch searchParameters)
        {
            var result = await serviceService.GetAsync(searchParameters);
            return result.ConvertToActionResult(System.Net.HttpStatusCode.OK);
        }
    }
}
