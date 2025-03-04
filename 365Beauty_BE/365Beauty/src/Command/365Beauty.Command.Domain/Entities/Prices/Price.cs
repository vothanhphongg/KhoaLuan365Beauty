using _365Beauty.Command.Domain.Abstractions.Aggregates;

namespace _365Beauty.Command.Domain.Entities.Prices
{
    public class Price : AggregateRoot<int>
    {
        public int SalonServiceId { get; set; }
        public Decimal BasePrice { get; set; }
        public Decimal FinalPrice { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int IsActived { get; set; }
    }
}
