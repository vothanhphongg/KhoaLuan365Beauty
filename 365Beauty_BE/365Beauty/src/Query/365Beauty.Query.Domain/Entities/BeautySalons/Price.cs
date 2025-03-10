using _365Beauty.Query.Domain.Abstractions.Aggregates;

namespace _365Beauty.Query.Domain.Entities.BeautySalons
{
    public class Price : AggregateRoot<int>
    {
        public int SalonServiceId { get; set; }
        public decimal BasePrice { get; set; }
        public decimal FinalPrice { get; set; }
        public DateTime CreatedDate { get; set; }
        public int IsActived { get; set; }
    }
}
