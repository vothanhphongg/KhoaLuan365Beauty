using _365Beauty.Command.Domain.Constants.Bookings;
using _365Beauty.Command.Domain.Entities.Bookings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _365Beauty.Command.Persistence.Configurations.Bookings
{
    public class BookingTimesConfig : IEntityTypeConfiguration<BookingTimes>
    {
        public void Configure(EntityTypeBuilder<BookingTimes> builder)
        {
            builder.ToTable(BookingTimesConst.TABLE_NAME);

            builder.HasKey(x => new { x.BookingId, x.TimeId, });
            builder.Property(x => x.BookingId).HasColumnName(BookingConst.FIELD_BOOKING_ID);
            builder.Property(x => x.TimeId).HasColumnName(TimeConst.FIELD_TIME_ID);
        }
    }
}