using _365Beauty.Command.Domain.Abstractions.Aggregates;

namespace _365Beauty.Command.Domain.Entities.BeautySalons
{
    public class BeautySalonImage : AggregateRoot<int>
    {
        public int SalonId { get; set; }
        public string? ImageUrl { get; set; }
    }
}