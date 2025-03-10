using _365Beauty.Contract.Shared;
using _365Beauty.Query.Application.DTOs.Users;
using MediatR;

namespace _365Beauty.Query.Application.Queries.Users.UserRatings
{
    public class GetAllUSerRatingQuery : IRequest<Result<List<UserRatingFullDTO>>>
    {
        public int SalonServiceId { get; set; }
    }
}