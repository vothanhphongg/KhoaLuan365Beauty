using _365Beauty.Query.Domain.Abstractions.Aggregates;

namespace _365Beauty.Query.Domain.Entities.Bookings
{
    public class BookingType : AggregateRoot<int>
    {
        public string Name { get; set; }
    }
}