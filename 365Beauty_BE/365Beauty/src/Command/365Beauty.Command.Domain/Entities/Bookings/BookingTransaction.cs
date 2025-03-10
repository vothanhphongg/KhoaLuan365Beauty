using _365Beauty.Command.Domain.Abstractions.Aggregates;

namespace _365Beauty.Command.Domain.Entities.Bookings
{
    public class BookingTransaction : AggregateRoot<int>
    {
        public int UserBookId { get; set; }
        public Decimal Amount { get; set; }
        public string? BankCode { get; set; }
        public string? BankTranNo { get; set; }
        public string? CardType { get; set; }
        public string? OrderInfo { get; set; }
        public DateTime PayDate { get; set; } 
        public string? ResponseCode { get; set; }
        public string? TransactionNo { get; set; }
        public string? Status { get; set; }
    }
}