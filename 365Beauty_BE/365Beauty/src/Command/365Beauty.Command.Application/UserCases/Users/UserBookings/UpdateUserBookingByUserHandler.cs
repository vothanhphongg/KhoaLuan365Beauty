using _365Beauty.Command.Application.Commands.Users.UserBookings;
using _365Beauty.Command.Domain.Abstractions.Repositories.Users;
using _365Beauty.Command.Domain.Constants.Users;
using _365Beauty.Command.Domain.Entities.Users;
using _365Beauty.Contract.Shared;
using MediatR;

namespace _365Beauty.Command.Application.UserCases.Users.UserBookings
{
    public class UpdateUserBookingByUserHandler : IRequestHandler<UpdateUserBookingByUserCommand, Result<object>>
    {
        private readonly IUserBookingRepository userBookingRepository;
        private readonly IUserRatingRepository userRatingRepository;

        public UpdateUserBookingByUserHandler(IUserBookingRepository userBookingRepository, IUserRatingRepository userRatingRepository)
        {
            this.userBookingRepository = userBookingRepository;
            this.userRatingRepository = userRatingRepository;
        }
        public async Task<Result<object>> Handle(UpdateUserBookingByUserCommand request, CancellationToken cancellationToken)
        {
            var entity = await userBookingRepository.FindByIdAsync(request.Id);
            entity.IsActived = request.IsActived;
            using var transaction = await userBookingRepository.BeginTransactionAsync(cancellationToken);
            try
            {
                userBookingRepository.Update(entity);
                await userBookingRepository.SaveChangesAsync(cancellationToken);
                if (request.IsActived == UserBookingConst.RATTING)
                {
                    var rating = new UserRating
                    {
                        UserId = (int)request.UserId!,
                        SalonServiceId = (int)request.SalonServiceId!,
                        Comment = request.Comment,
                        Count = (float)request.Count!,
                        CreatedDate = DateTime.UtcNow,
                    };
                    userRatingRepository.Add(rating);
                    await userRatingRepository.SaveChangesAsync(cancellationToken);
                }

                transaction.Commit();
                return Result.Ok();
            }
            catch (Exception)
            {
                // Rollback transaction
                transaction.Rollback();
                throw;
            }
        }
    }
}