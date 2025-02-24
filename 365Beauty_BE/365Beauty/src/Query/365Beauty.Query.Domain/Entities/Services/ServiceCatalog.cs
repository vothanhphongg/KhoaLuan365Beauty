using _365Beauty.Query.Domain.Abstractions.Aggregates;
using _365Beauty.Query.Domain.Entities.BeautySalons;
using _365Beauty.Query.Domain.Entities.Staffs;
using Newtonsoft.Json;

namespace _365Beauty.Query.Domain.Entities.Services
{
    public class ServiceCatalog : AggregateRoot<int>
    {
        public string Name { get; set; }
        public string? Icon { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UserIdCreated { get; set; }
        public int IsActived { get; set; }
        [JsonIgnore]
        public ICollection<StaffCatalog>? StaffCatalogs { get; set; }
        [JsonIgnore]
        public List<BeautySalonService>? BeautySalonServices { get; set; }

    }
}