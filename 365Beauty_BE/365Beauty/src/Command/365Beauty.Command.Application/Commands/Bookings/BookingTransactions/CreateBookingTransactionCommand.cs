using _365Beauty.Contract.Shared;
using MediatR;

namespace _365Beauty.Command.Application.Commands.Bookings.BookingTransactions
{
    public class CreateBookingTransactionCommand : IRequest<Result<object>>
    {
        public int UserBookId { get; set; }
        public Decimal Amount { get; set; }
        public string? BankCode { get; set; }
        public string? BankTranNo { get; set; }
        public string? CardType { get; set; }
        public string? OrderInfo { get; set; }
        public string? ResponseCode { get; set; }
        public string? TransactionNo { get; set; }
        public string? Status { get; set; }
    }
}
