using _365Beauty.Command.Domain.Abstractions.Aggregates;

namespace _365Beauty.Command.Domain.Entities.Localizations
{
    public class Ward : AggregateRoot<string>
    {
        public string Name { get; set; }
        public string DistrictId { get; set; }
    }
}