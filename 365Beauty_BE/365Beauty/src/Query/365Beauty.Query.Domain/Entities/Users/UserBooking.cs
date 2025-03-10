using _365Beauty.Query.Domain.Abstractions.Aggregates;
using _365Beauty.Query.Domain.Entities.BeautySalons;
using _365Beauty.Query.Domain.Entities.Bookings;
using _365Beauty.Query.Domain.Entities.Staffs;

namespace _365Beauty.Query.Domain.Entities.Users
{
    public class UserBooking : AggregateRoot<int>
    {
        public int SalonServiceId { get; set; }
        public int UserId { get; set; }
        public int TimeId { get; set; }
        public int? StaffId { get; set; }
        public int BookingTypeId { get; set; }
        public string? Description { get; set; }
        public DateTime BookingDate { get; set; }
        public DateTime CreateDate { get; set; }
        public int IsActived { get; set; }
        public StaffCatalog? StaffCatalog { get; set; }
        public Time? Time { get; set; }
        public Price Price { get; set; }
        public BeautySalonService? BeautySalonService { get; set; }
        public BookingType? BookingType { get; set; }
        public UserAccount? UserAccount { get; set; }
        public UserInformation? UserInformation { get; set; }
    }
}