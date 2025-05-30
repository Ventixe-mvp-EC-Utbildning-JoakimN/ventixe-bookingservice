using Microsoft.AspNetCore.Mvc;
using Ventixe.BookingService.Data;
using Ventixe.BookingService.Models;
using BookingServiceClass = Ventixe.BookingService.Services.BookingService;

namespace Ventixe.BookingService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingsController : Controller
    {
        private readonly BookingServiceClass _bookingService;

        public BookingsController(BookingServiceClass bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Booking>> GetAll()
        {
            return Ok(_bookingService.GetAll());
        }

        [HttpPost]
        public async Task<ActionResult<Booking>> Create([FromBody] Booking booking)
        {
            var saved = await _bookingService.Create(booking);
            return CreatedAtAction(nameof(GetAll), new { id = saved.Id }, saved);
        }
    }
}

