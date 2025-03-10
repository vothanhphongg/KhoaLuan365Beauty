using _365Beauty.Contract.Shared;
using _365Beauty.Query.Application.DTOs.Users;
using MediatR;

namespace _365Beauty.Query.Application.Queries.Users.UserBookings
{
    public class GetAllUserBookingBySalonIdQuery : IRequest<Result<List<UserBookingSalonDTO>>>
    {
        public int SalonId { get; set; }
        public int IsActived { get; set; }
    }
}