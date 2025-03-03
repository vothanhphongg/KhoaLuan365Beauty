using _365Beauty.Query.Domain.Abstractions.Aggregates;
using _365Beauty.Query.Domain.Entities.Prices;
using _365Beauty.Query.Domain.Entities.Services;
using System.Text.Json.Serialization;

namespace _365Beauty.Query.Domain.Entities.BeautySalons
{
    public class BeautySalonService : AggregateRoot<int>
    {
        public int SalonId { get; set; }
        public int ServiceId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public DateTime CreatedDate { get; set; }
        public int IsActived { get; set; }
        public Price? Price { get; set; }
        [JsonIgnore]
        public BeautySalonCatalog? SalonCatalog { get; set; }
        [JsonIgnore]
        public ServiceCatalog? ServiceCatalog { get; set; }

    }
}