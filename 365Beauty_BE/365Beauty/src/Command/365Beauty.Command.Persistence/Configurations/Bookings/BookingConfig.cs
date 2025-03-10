using _365Beauty.Command.Domain.Constants.BeautySalons;
using _365Beauty.Command.Domain.Constants.Bookings;
using _365Beauty.Command.Domain.Entities.Bookings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _365Beauty.Command.Persistence.Configurations.Bookings
{
    public class BookingConfig : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.ToTable(BookingConst.TABLE_NAME);

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName(BookingConst.FIELD_BOOKING_ID);
            builder.Property(x => x.SalonServiceId).HasColumnName(BeautySalonServiceConst.FIELD_BEAUTY_SALON_SERVICE_ID);
            builder.Property(x => x.Count).HasColumnName(BookingConst.FIELD_BOOKING_COUNT);

            builder.HasMany(x => x.BookingTimes).WithOne().HasForeignKey(x => x.BookingId);
        }
    }
}