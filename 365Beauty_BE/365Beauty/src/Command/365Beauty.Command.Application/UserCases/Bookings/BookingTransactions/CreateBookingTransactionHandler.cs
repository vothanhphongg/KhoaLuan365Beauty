using _365Beauty.Command.Application.Commands.Bookings.BookingTransactions;
using _365Beauty.Command.Domain.Abstractions.Repositories.Bookings;
using _365Beauty.Command.Domain.Abstractions.Repositories.Users;
using _365Beauty.Command.Domain.Constants.Users;
using _365Beauty.Command.Domain.Entities.Bookings;
using _365Beauty.Contract.Shared;
using MediatR;

namespace _365Beauty.Command.Application.UserCases.Bookings.BookingTransactions
{
    public class CreateBookingTransactionHandler : IRequestHandler<CreateBookingTransactionCommand, Result<object>>
    {
        private readonly IUserBookingRepository userBookingRepository;
        private readonly IBookingTransactionRepository bookingTransactionRepository;

        public CreateBookingTransactionHandler(IUserBookingRepository userBookingRepository,
                                               IBookingTransactionRepository bookingTransactionRepository)
        {
            this.userBookingRepository = userBookingRepository;
            this.bookingTransactionRepository = bookingTransactionRepository;
        }
        public async Task<Result<object>> Handle(CreateBookingTransactionCommand request, CancellationToken cancellationToken)
        {
            BookingTransaction entity = new BookingTransaction
            {
                UserBookId = request.UserBookId,
                Amount = request.Amount,
                BankCode = request.BankCode,
                BankTranNo = request.BankTranNo,
                CardType = request.CardType,
                OrderInfo = request.OrderInfo,
                PayDate = DateTime.UtcNow,
                ResponseCode = request.ResponseCode,
                TransactionNo = request.TransactionNo,
                Status = request.Status,
            };
            
            var userBook = await userBookingRepository.FindByIdAsync(entity.UserBookId);
            using var transaction = await bookingTransactionRepository.BeginTransactionAsync(cancellationToken);
            try
            {
                if (entity.ResponseCode == "00")
                {
                    userBook.IsActived = UserBookingConst.CONFIRMED;
                    userBookingRepository.Update(userBook);
                    await userBookingRepository.SaveChangesAsync(cancellationToken);

                }
                bookingTransactionRepository.Add(entity);
                await bookingTransactionRepository.SaveChangesAsync(cancellationToken);

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