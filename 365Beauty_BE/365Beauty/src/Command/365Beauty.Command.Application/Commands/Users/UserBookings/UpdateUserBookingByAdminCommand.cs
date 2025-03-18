using _365Beauty.Contract.Shared;
using MediatR;

namespace _365Beauty.Command.Application.Commands.Users.UserBookings
{
    public class UpdateUserBookingByAdminCommand : IRequest<Result<object>>
    {
        public int Id { get; set; }
        public int? StaffId { get; set; }
        public Decimal? Amount { get; set; }
        public int IsActived { get; set; }
    }
}