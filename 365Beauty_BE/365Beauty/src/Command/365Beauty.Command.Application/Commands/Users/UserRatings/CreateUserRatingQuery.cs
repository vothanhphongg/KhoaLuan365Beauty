using _365Beauty.Contract.Shared;
using MediatR;

namespace _365Beauty.Command.Application.Commands.Users.UserRatings
{
    public class CreateUserRatingQuery : IRequest<Result<object>>
    {
        public int UserId { get; set; }
        public int SalonServiceId { get; set; }
        public string? Comment { get; set; }
        public double Count { get; set; }
    }
}