using _365Beauty.Query.Domain.Abstractions.Aggregates;

namespace _365Beauty.Query.Domain.Entities.Bookings
{
    public class HistoryTransaction : AggregateRoot<int>
    {
        public int UserBookId { get; set; }
        public Decimal Amount { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}