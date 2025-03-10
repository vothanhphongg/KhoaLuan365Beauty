namespace _365Beauty.Query.Application.DTOs.Users
{
    public class UserBookingActivedDTO
    {
        public int Id { get; set; }
        public int TimeId { get; set; }
        public string ServiceName { get; set; }
        public string SalonServiceName { get; set; }
        public string SalonServiceImage { get; set; }
        public string SalonName { get; set; }
        public string AddressFullAscending { get; set; }
        public DateTime BookingDate { get; set; }
        public string Times {  get; set; }
        public string BookingTypeName { get; set; }
        public Decimal Price { get; set; }
        public int IsActived { get; set; }
        public string Actived {  get; set; }
    }
}