using _365Beauty.Query.Domain.Abstractions.Aggregates;

namespace _365Beauty.Query.Domain.Entities.Staffs
{
    public class OccupationCatalog : AggregateRoot<int>
    {
        public string Name { get; set; }
    }
}