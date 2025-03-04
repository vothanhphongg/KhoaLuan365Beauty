using _365Beauty.Contract.Shared;
using MediatR;

namespace _365Beauty.Command.Application.Commands.Bookings.BookingTypes
{
    public class CreateBookingTypeCommand : IRequest<Result<object>>
    {
        public string Name { get; set; }
    }
}
