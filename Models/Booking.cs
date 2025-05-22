namespace Ventixe.BookingService.Models;

public class Booking
{
    public int Id { get; set; }
    public int EventId { get; set; }
    public DateTime BookedAt { get; set; } = DateTime.UtcNow;
}
