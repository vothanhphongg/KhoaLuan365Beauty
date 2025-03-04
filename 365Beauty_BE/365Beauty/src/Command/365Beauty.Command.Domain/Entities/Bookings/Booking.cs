using _365Beauty.Command.Domain.Abstractions.Aggregates;

namespace _365Beauty.Command.Domain.Entities.Bookings
{
    public class Booking : AggregateRoot<int>
    {
        public int SalonServiceId { get; set; }
        public int Count { get; set; }
        public List<BookingTimes>? BookingTimes { get; set; }
    }
}
