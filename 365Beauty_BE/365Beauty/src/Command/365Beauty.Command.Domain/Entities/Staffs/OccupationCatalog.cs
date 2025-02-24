using _365Beauty.Command.Domain.Abstractions.Aggregates;

namespace _365Beauty.Command.Domain.Entities.Staffs
{
    public class OccupationCatalog : AggregateRoot<int>
    {
        public string Name { get; set; }
        public void Update(string? name = null)
        {
            Name = name ?? Name;
        }
    }
}