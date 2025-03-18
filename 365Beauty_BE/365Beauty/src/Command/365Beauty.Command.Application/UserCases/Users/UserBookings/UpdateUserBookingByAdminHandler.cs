using _365Beauty.Command.Application.Commands.Users.UserBookings;
using _365Beauty.Command.Domain.Abstractions.Repositories.Bookings;
using _365Beauty.Command.Domain.Abstractions.Repositories.Users;
using _365Beauty.Command.Domain.Constants.Users;
using _365Beauty.Command.Domain.Entities.Bookings;
using _365Beauty.Contract.Shared;
using MediatR;

namespace _365Beauty.Command.Application.UserCases.Users.UserBookings
{
    public class UpdateUserBookingByAdminHandler : IRequestHandler<UpdateUserBookingByAdminCommand, Result<object>>
    {
        private readonly IUserBookingRepository userBookingRepository;
        private readonly IHistoryTransactionRepository historyTransactionRepository;

        public UpdateUserBookingByAdminHandler(IUserBookingRepository userBookingRepository, IHistoryTransactionRepository historyTransactionRepository)
        {
            this.userBookingRepository = userBookingRepository;
            this.historyTransactionRepository = historyTransactionRepository;
        }
        public async Task<Result<object>> Handle(UpdateUserBookingByAdminCommand request, CancellationToken cancellationToken)
        {
            var entity = await userBookingRepository.FindByIdAsync(request.Id);
            entity.IsActived = request.IsActived;
            entity.StaffId = request.StaffId ?? entity.StaffId;
           
            using var transaction = await userBookingRepository.BeginTransactionAsync(cancellationToken);
            try
            {
                userBookingRepository.Update(entity);
                await userBookingRepository.SaveChangesAsync(cancellationToken);
                if (request.IsActived == UserBookingConst.SUCCESSED)
                {
                    var hisTransaction = new HistoryTransaction
                    {
                        UserBookId = request.Id,
                        Amount = request.Amount!.Value,
                        CreatedDate = DateTime.UtcNow,
                    };
                    historyTransactionRepository.Add(hisTransaction);
                    await historyTransactionRepository.SaveChangesAsync(cancellationToken);
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