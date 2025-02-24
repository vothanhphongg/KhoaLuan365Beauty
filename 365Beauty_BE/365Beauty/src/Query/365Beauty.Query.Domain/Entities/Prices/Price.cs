using _365Beauty.Query.Domain.Abstractions.Aggregates;

namespace _365Beauty.Query.Domain.Entities.Prices
{
    public class Price : AggregateRoot<int>
    {
        public int SalonServiceId { get; set; }
        public Decimal BasePrice { get; set; }
        public Decimal FinalPrice { get; set; }
        public DateTime CreatedDate { get; set; }
        public int IsActived { get; set; }
    }
}
