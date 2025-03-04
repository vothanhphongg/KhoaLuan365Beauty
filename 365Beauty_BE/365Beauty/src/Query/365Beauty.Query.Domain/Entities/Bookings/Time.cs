using _365Beauty.Query.Domain.Abstractions.Aggregates;
using System.Text.Json.Serialization;

namespace _365Beauty.Query.Domain.Entities.Bookings
{
    public class Time : AggregateRoot<int>
    {
        public string Times { get; set; }
        [JsonIgnore]
        public ICollection<Booking>? Bookings { get; set; }
    }
}