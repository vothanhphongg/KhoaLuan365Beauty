using _365Beauty.Contract.Shared;
using MediatR;

namespace _365Beauty.Command.Application.Commands.Users.UserBookings
{
    public class ConfirmSuccessUserBookingCommand : IRequest<Result<object>>
    {
        public int Id { get; set; }
        public int UserBookId { get; set; }
        public Decimal Amount { get; set; }
    }
}