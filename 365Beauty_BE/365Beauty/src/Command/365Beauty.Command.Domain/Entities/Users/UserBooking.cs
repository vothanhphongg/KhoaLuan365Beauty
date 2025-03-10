using _365Beauty.Command.Domain.Abstractions.Aggregates;

namespace _365Beauty.Command.Domain.Entities.Users
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
    }
}