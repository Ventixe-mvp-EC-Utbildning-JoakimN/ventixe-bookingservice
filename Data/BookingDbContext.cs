using Microsoft.EntityFrameworkCore;
using Ventixe.BookingService.Models;

namespace Ventixe.BookingService.Data;

public class BookingDbContext : DbContext
{
    public BookingDbContext(DbContextOptions<BookingDbContext> options) : base(options) {}

    public DbSet<Booking> Bookings => Set<Booking>();
}
