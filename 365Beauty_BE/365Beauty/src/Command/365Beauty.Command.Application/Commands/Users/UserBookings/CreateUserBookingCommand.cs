using _365Beauty.Contract.Shared;
using MediatR;

namespace _365Beauty.Command.Application.Commands.Users.UserBookings
{
    public class CreateUserBookingCommand : IRequest<Result<object>>
    {
        public int UserId { get; set; }
        public int SalonServiceId { get; set; }
        public int TimeId { get; set; }
        public int BookingTypeId { get; set; }
        public int? StaffId { get; set; }
        public string? Description { get; set; }
        public DateTime BookingDate { get; set; }
    }
}