using _365Beauty.Command.Domain.Abstractions.Aggregates;

namespace _365Beauty.Command.Domain.Entities.Services
{
    public class ServiceCatalog : AggregateRoot<int>
    {
        public string Name { get; set; }
        public string? Icon { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UserIdCreated { get; set; }
        public int IsActived { get; set; }

        public void Update(string? name = null, string? icon = null)
        {
            Name = name ?? Name;
            Icon = icon ?? Icon;
        }
    }
}