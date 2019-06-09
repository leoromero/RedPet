using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RedPet.API.Extensions;
using RedPet.Common.Models.Booking;
using RedPet.Core;

namespace RedPetAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiVersion("1")]
    [Authorize]
    public class BookingsController : Controller
    {
        private readonly IBookingService bookingService;

        public BookingsController(IBookingService bookingService)
        {
            this.bookingService = bookingService;
        }

        [HttpGet]
        public async Task<ActionResult<List<BookingModel>>> GetAsync()
        {
            var result = await bookingService.GetAsync();
            return result.ConvertToActionResult(System.Net.HttpStatusCode.OK);
        }        
    }
}
