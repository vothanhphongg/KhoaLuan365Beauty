using _365Beauty.Command.Domain.Constants.Bookings;
using _365Beauty.Command.Domain.Entities.Bookings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _365Beauty.Command.Persistence.Configurations.Bookings
{
    public class BookingTypeConfig : IEntityTypeConfiguration<BookingType>
    {
        public void Configure(EntityTypeBuilder<BookingType> builder)
        {
            builder.ToTable(BookingTypeConst.TABLE_NAME);

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName(BookingTypeConst.FIELD_BOOKING_TYPE_ID);
            builder.Property(x => x.Name).HasColumnName(BookingTypeConst.FIELD_BOOKING_TYPE_NAME);
        }
    }
}