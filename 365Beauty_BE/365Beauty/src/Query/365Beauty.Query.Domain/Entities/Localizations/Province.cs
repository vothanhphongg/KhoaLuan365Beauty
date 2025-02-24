using _365Beauty.Query.Domain.Abstractions.Aggregates;
using Newtonsoft.Json;

namespace _365Beauty.Query.Domain.Entities.Localizations
{
    public class Province : AggregateRoot<string>
    {
        public string Name { get; set; }

        [JsonIgnore]
        public List<District> Districts { get; set; }
    }
}