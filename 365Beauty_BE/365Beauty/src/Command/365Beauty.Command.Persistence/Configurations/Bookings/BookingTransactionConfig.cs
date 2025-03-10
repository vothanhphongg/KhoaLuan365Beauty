using _365Beauty.Command.Domain.Constants.Bookings;
using _365Beauty.Command.Domain.Constants.Users;
using _365Beauty.Command.Domain.Entities.Bookings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _365Beauty.Command.Persistence.Configurations.Bookings
{
    public class BookingTransactionConfig : IEntityTypeConfiguration<BookingTransaction>
    {
        public void Configure(EntityTypeBuilder<BookingTransaction> builder)
        {
            builder.ToTable(BookingTransactionConst.TABLE_NAME);

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName(BookingTransactionConst.FIELD_TRANSACTION_ID);
            builder.Property(x => x.UserBookId).HasColumnName(UserBookingConst.FIELD_USER_BOOKING_ID);
            builder.Property(x => x.Amount).HasColumnName(BookingTransactionConst.FIELD_TRANSACTION_AMOUNT);
            builder.Property(x => x.BankCode).HasColumnName(BookingTransactionConst.FIELD_TRANSACTION_BANK_CODE);
            builder.Property(x => x.BankTranNo).HasColumnName(BookingTransactionConst.FIELD_TRANSACTION_BANK_TRAN_NO);
            builder.Property(x => x.CardType).HasColumnName(BookingTransactionConst.FIELD_TRANSACTION_CARD_TYPE);
            builder.Property(x => x.OrderInfo).HasColumnName(BookingTransactionConst.FIELD_TRANSACTION_ORDER_INFO);
            builder.Property(x => x.PayDate).HasColumnName(BookingTransactionConst.FIELD_TRANSACTION_PAY_DATE);
            builder.Property(x => x.ResponseCode).HasColumnName(BookingTransactionConst.FIELD_TRANSACTION_REPONSE_CODE);
            builder.Property(x => x.TransactionNo).HasColumnName(BookingTransactionConst.FIELD_TRANSACTION_NO);
            builder.Property(x => x.Status).HasColumnName(BookingTransactionConst.FIELD_TRANSACTION_STATUS);
        }
    }
}