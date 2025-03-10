using _365Beauty.Contract.Shared;
using MediatR;

namespace _365Beauty.Command.Application.Commands.BeautySalons.PriceAndBookings
{
    public class CreatePriceAndBookingCommand : IRequest<Result<object>>
    {
        public int SalonServiceId { get; set; }
        public decimal BasePrice { get; set; }
        public decimal FinalPrice { get; set; }
        public int BookingCount { get; set; }
        public List<int>? BookingTimes { get; set; }
    }
}
