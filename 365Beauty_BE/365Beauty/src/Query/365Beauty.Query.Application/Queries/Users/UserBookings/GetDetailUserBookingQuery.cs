using _365Beauty.Contract.Shared;
using _365Beauty.Query.Domain.Entities.Users;
using MediatR;

namespace _365Beauty.Query.Application_Queries.Users.UserBookings
{
    public class GetDetailUserBookingQuery : IRequest<Result<UserBooking>>
    {
        public int Id { get; set; }
    }
}