using Newtonsoft.Json;

namespace _365Beauty.Query.Domain.Entities.Bookings
{
    public class BookingTimes
    {
        public int BookingId { get; set; }
        public int TimeId { get; set; }
        [JsonIgnore]
        public Booking? Booking { get; set; }
        [JsonIgnore]
        public Time? Time { get; set; }
    }
}