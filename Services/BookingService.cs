using Ventixe.BookingService.Data;
using Ventixe.BookingService.Models;

namespace Ventixe.BookingService.Services
{
    public class BookingService
    {
        private readonly BookingDbContext _context;
        private readonly IHttpClientFactory _httpClientFactory;

        public BookingService(BookingDbContext context, IHttpClientFactory httpClientFactory)
        {
            _context = context;
            _httpClientFactory = httpClientFactory;
        }

        public IEnumerable<Booking> GetAll() => _context.Bookings.ToList();

        public async Task<Booking> Create(Booking booking)
        {
            booking.BookedAt = DateTime.UtcNow;

            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();

            var client = _httpClientFactory.CreateClient("NotificationService");
            Console.WriteLine($"[BookingService] Booking created for eventId {booking.EventId}");
            var response = await client.PostAsJsonAsync("api/notifications", booking.EventId);
            if(!response.IsSuccessStatusCode)
            {
                Console.WriteLine($"Notification failed: {response.StatusCode}");
            }
            else
            {
                Console.WriteLine($" Notification sent for eventId: {booking.EventId}");
            }

                return booking;
        }
    }
}


