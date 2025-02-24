using _365Beauty.Command.Domain.Abstractions.Aggregates;

namespace _365Beauty.Command.Domain.Entities.Localizations
{
    public class Province : AggregateRoot<string>
    {
        public string Name { get; set; }
    }
}