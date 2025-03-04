using _365Beauty.Contract.Shared;
using MediatR;

namespace _365Beauty.Command.Application.Commands.Prices
{
    public class CreatePriceBookingCommand : IRequest<Result<object>>
    {
        public int SalonServiceId { get; set; }
        public Decimal BasePrice { get; set; }
        public Decimal FinalPrice { get; set; }
        public int BookingCount { get; set; }
    }
}
