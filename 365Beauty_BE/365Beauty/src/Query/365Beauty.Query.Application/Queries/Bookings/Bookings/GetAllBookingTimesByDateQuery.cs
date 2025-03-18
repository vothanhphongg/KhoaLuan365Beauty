using _365Beauty.Contract.Shared;
using _365Beauty.Query.Domain.Entities.Bookings;
using MediatR;

namespace _365Beauty.Query.Application.Queries.Bookings.Bookings
{
    public class GetAllBookingTimesByDateQuery : IRequest<Result<List<Time>>>
    {
        public int SalonServiceId { get; set; }
        public DateTime BookingDate { get; set; }
    }
}
