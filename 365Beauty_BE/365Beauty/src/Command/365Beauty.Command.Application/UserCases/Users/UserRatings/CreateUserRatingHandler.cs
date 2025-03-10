using _365Beauty.Command.Application.Commands.Users.UserRatings;
using _365Beauty.Command.Domain.Abstractions.Repositories.Users;
using _365Beauty.Command.Domain.Entities.Users;
using _365Beauty.Contract.Shared;
using MediatR;

namespace _365Beauty.Command.Application.UserCases.Users.UserRatings
{
    public class CreateUserRatingHandler : IRequestHandler<CreateUserRatingQuery, Result<object>>
    {
        private readonly IUserRatingRepository userRatingRepository;

        public CreateUserRatingHandler(IUserRatingRepository userRatingRepository)
        {
            this.userRatingRepository = userRatingRepository;
        }
        public async Task<Result<object>> Handle(CreateUserRatingQuery request, CancellationToken cancellationToken)
        {
            var entity = new UserRating
            {
                UserId = request.UserId,
                SalonServiceId = request.SalonServiceId,
                Comment = request.Comment,
                Count = request.Count,
                CreatedDate = DateTime.UtcNow,
            };
            using var transaction = await userRatingRepository.BeginTransactionAsync(cancellationToken);
            try
            {
                userRatingRepository.Add(entity);
                await userRatingRepository.SaveChangesAsync(cancellationToken);
               
                transaction.Commit();
                return Result.Ok();
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }
        }
    }
}