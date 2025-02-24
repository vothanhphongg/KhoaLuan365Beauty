using _365Beauty.Query.Domain.Abstractions.Aggregates;
using Newtonsoft.Json;

namespace _365Beauty.Query.Domain.Entities.Localizations
{
    public class District : AggregateRoot<string>
    {
        public string Name { get; set; }
        public string ProvinceId { get; set; }

        [JsonIgnore]
        public List<Ward> Wards { get; set; }
    }
}