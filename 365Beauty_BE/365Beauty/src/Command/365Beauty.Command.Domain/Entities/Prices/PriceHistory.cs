using _365Beauty.Command.Domain.Abstractions.Aggregates;

namespace _365Beauty.Command.Domain.Entities.Prices
{
    public class PriceHistory : AggregateRoot<int>
    {
        public int SalonServiceId { get; set; }
        public Decimal Price { get; set; }
        public  DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int IsActived { get; set; }
    }
}