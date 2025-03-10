using _365Beauty.Query.Domain.Constants.Bookings;
using _365Beauty.Query.Domain.Entities.Bookings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _365Beauty.Query.Persistence.Configurations.Bookings
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