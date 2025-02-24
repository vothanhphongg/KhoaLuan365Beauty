using _365Beauty.Query.Domain.Abstractions.Aggregates;

namespace _365Beauty.Query.Domain.Entities.Localizations
{
    public class Ward : AggregateRoot<string>
    {
        public string Name { get; set; }
        public string DistrictId { get; set; }
    }
}