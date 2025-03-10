namespace _365Beauty.Query.Application.DTOs.BeautySalons
{
    public class BeautySalonServiceWithPriceAndBookingDTO
    {
        public int Id { get; set; }
        public int SalonId { get; set; }
        public string Name { get; set; }
        public string? Image { get; set; }
        public int BookingCount { get; set; }
        public Decimal? BasePrice { get; set; }
        public Decimal? FinalPrice { get; set; }
        public List<int>? BookingTimes { get; set; }
    }
}
