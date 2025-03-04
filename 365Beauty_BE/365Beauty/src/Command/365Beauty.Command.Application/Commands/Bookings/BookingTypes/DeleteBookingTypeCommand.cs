using _365Beauty.Contract.Shared;
using MediatR;

namespace _365Beauty.Command.Application.Commands.Bookings.BookingTypes
{
    public class DeleteBookingTypeCommand : IRequest<Result<object>>
    {
        public int Id { get; set; }
    }
}