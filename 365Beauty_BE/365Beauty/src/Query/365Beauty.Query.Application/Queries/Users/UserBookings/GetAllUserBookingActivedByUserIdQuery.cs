using _365Beauty.Contract.Shared;
using _365Beauty.Query.Application.DTOs.Users;
using MediatR;

namespace _365Beauty.Query.Application_Queries.Users.UserBookings
{
    public class GetAllUserBookingActivedByUserIdQuery : IRequest<Result<List<UserBookingActivedDTO>>>
    {
        public int UserId { get; set; }
        public int IsActived { get; set; }
    }
}