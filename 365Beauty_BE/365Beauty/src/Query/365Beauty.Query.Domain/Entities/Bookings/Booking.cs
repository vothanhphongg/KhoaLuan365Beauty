using _365Beauty.Query.Domain.Abstractions.Aggregates;

namespace _365Beauty.Query.Domain.Entities.Bookings
{
    public class Booking : AggregateRoot<int>
    {
        public int SalonServiceId { get; set; }
        public int Count { get; set; }
        public ICollection<Time>? Times { get; set; }
    }
}
