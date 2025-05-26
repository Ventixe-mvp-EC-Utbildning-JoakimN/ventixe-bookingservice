using Ventixe.BookingService.Data;
using Ventixe.BookingService.Models;

namespace Ventixe.BookingService.Services
{
    public class BookingService
    {
        private readonly BookingDbContext _context;

        public BookingService(BookingDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Booking> GetAll() => _context.Bookings.ToList();

        public Booking Create(Booking booking)
        {
            _context.Bookings.Add(booking);
            _context.SaveChanges();
            return booking;
        }
    }
}


