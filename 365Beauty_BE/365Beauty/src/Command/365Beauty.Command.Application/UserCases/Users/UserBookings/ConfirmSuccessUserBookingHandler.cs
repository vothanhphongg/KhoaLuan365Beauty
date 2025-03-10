using _365Beauty.Command.Application.Commands.Users.UserBookings;
using _365Beauty.Command.Domain.Abstractions.Repositories.Bookings;
using _365Beauty.Command.Domain.Abstractions.Repositories.Users;
using _365Beauty.Command.Domain.Constants.Users;
using _365Beauty.Command.Domain.Entities.Bookings;
using _365Beauty.Contract.Shared;
using MediatR;

namespace _365Beauty.Command.Application.UserCases.Users.UserBookings
{
    public class ConfirmSuccessUserBookingHandler : IRequestHandler<ConfirmSuccessUserBookingCommand, Result<object>>
    {
        private readonly IUserBookingRepository userBookingRepository;
        private readonly IHistoryTransactionRepository historyTransactionRepository;

        public ConfirmSuccessUserBookingHandler(IUserBookingRepository userBookingRepository, IHistoryTransactionRepository historyTransactionRepository)
        {
            this.userBookingRepository = userBookingRepository;
            this.historyTransactionRepository = historyTransactionRepository;
        }
        public async Task<Result<object>> Handle(ConfirmSuccessUserBookingCommand request, CancellationToken cancellationToken)
        {
            var userBooking = await userBookingRepository.FindByIdAsync(request.Id);
            userBooking.IsActived = UserBookingConst.SUCCESSED;

            var hisTransaction = new HistoryTransaction
            {
                UserBookId = request.Id,
                Amount = request.Amount,
                CreatedDate = DateTime.UtcNow,
            };
            using var transaction = await userBookingRepository.BeginTransactionAsync(cancellationToken);
            try
            {
                userBookingRepository.Update(userBooking);
                await userBookingRepository.SaveChangesAsync(cancellationToken);

                historyTransactionRepository.Add(hisTransaction);
                await historyTransactionRepository.SaveChangesAsync(cancellationToken);
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