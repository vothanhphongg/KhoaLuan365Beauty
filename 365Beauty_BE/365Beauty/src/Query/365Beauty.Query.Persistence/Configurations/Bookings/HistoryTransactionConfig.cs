using _365Beauty.Query.Domain.Constants.Bookings;
using _365Beauty.Query.Domain.Constants.Users;
using _365Beauty.Query.Domain.Entities.Bookings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _365Beauty.Query.Persistence.Configurations.HistoryTransactions
{
    public class HistoryTransactionConfig : IEntityTypeConfiguration<HistoryTransaction>
    {
        public void Configure(EntityTypeBuilder<HistoryTransaction> builder)
        {
            builder.ToTable(HistoryTransactionConst.TABLE_NAME);

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName(HistoryTransactionConst.FIELD_HISTORY_TRANSACTION_ID);
            builder.Property(x => x.UserBookId).HasColumnName(UserBookingConst.FIELD_USER_BOOKING_ID);
            builder.Property(x => x.Amount).HasColumnName(HistoryTransactionConst.FIELD_HISTORY_AMOUNT);
            builder.Property(x => x.CreatedDate).HasColumnName(HistoryTransactionConst.FIELD_HISTORY_CREATED_DATE);
        }
    }
}