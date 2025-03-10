using _365Beauty.Contract.Shared;
using _365Beauty.Query.Application.DTOs.Users;
using _365Beauty.Query.Application.Queries.Users.UserRatings;
using _365Beauty.Query.Domain.Abstractions.Repositories.Users;
using MediatR;

namespace _365Beauty.Query.Application.UserCases.Users.UserRatings
{
    public class GetAllUserRatingHandler : IRequestHandler<GetAllUSerRatingQuery, Result<List<UserRatingFullDTO>>>
    {
        private readonly IUserRatingRepository userRatingRepository;

        public GetAllUserRatingHandler(IUserRatingRepository userRatingRepository)
        {
            this.userRatingRepository = userRatingRepository;
        }
        public async Task<Result<List<UserRatingFullDTO>>> Handle(GetAllUSerRatingQuery request, CancellationToken cancellationToken)
        {
            var rating = userRatingRepository.FindAll(false, x => x.SalonServiceId == request.SalonServiceId, x => x.UserInformation!).ToList();
            var entities = rating.Select(x => new UserRatingFullDTO
            {
                Id = x.Id,
                FullName = $"{x.UserInformation.FirstName} {x.UserInformation.LastName}",
                Img = x.UserInformation.Img,
                Comment = x.Comment,
                Count = x.Count,
                CreatedDate = x.CreatedDate,
            }).ToList();
            return await Task.FromResult(Result.Ok(entities));
        }
    }
}
