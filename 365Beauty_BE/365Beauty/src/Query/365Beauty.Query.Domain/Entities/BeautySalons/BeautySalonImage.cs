using _365Beauty.Query.Domain.Abstractions.Aggregates;

namespace _365Beauty.Query.Domain.Entities.BeautySalons
{
    public class BeautySalonImage : AggregateRoot<int>
    {
        public int SalonId { get; set; }
        public string? ImageUrl { get; set; }
    }
}