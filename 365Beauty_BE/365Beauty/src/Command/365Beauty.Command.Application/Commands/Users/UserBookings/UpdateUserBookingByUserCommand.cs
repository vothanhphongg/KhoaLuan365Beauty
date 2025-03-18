using _365Beauty.Contract.Shared;
using MediatR;

namespace _365Beauty.Command.Application.Commands.Users.UserBookings
{
    public class UpdateUserBookingByUserCommand : IRequest<Result<object>>
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? SalonServiceId { get; set; }
        public float? Count { get; set; }
        public string? Comment { get; set; }
        public int IsActived { get; set; }
    }
}