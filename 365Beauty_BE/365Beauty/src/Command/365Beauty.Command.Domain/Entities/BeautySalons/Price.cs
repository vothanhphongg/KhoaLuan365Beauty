using _365Beauty.Command.Domain.Abstractions.Aggregates;

namespace _365Beauty.Command.Domain.Entities.BeautySalons
{
    public class Price : AggregateRoot<int>
    {
        public int SalonServiceId { get; set; }
        public decimal BasePrice { get; set; }
        public decimal FinalPrice { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int IsActived { get; set; }
    }
}
