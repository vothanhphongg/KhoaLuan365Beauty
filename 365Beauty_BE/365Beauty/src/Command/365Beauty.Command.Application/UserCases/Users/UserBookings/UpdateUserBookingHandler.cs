using _365Beauty.Command.Application.Commands.Users.UserBookings;
using _365Beauty.Command.Domain.Abstractions.Repositories.Users;
using _365Beauty.Contract.Shared;
using MediatR;

namespace _365Beauty.Command.Application.UserCases.Users.UserBookings
{
    public class UpdateUserBookingHandler : IRequestHandler<UpdateUserBookingCommand, Result<object>>
    {
        private readonly IUserBookingRepository userBookingRepository;

        public UpdateUserBookingHandler(IUserBookingRepository userBookingRepository)
        {
            this.userBookingRepository = userBookingRepository;
        }
        public async Task<Result<object>> Handle(UpdateUserBookingCommand request, CancellationToken cancellationToken)
        {
            var entity = await userBookingRepository.FindByIdAsync(request.Id);
            entity.IsActived = request.IsActived;

            using var transaction = await userBookingRepository.BeginTransactionAsync(cancellationToken);
            try
            {
                userBookingRepository.Update(entity);
                await userBookingRepository.SaveChangesAsync(cancellationToken);
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