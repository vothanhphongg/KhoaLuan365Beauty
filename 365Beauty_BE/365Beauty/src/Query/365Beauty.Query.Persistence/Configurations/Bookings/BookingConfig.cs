using _365Beauty.Query.Domain.Constants.BeautySalons;
using _365Beauty.Query.Domain.Constants.Bookings;
using _365Beauty.Query.Domain.Entities.Bookings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _365Beauty.Query.Persistence.Configurations.Bookings
{
    public class BookingConfig : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.ToTable(BookingConst.TABLE_NAME);

            builder.HasKey(x => x.Id);
            builder.Ignore(x => x.Times);
            builder.Property(x => x.Id).HasColumnName(BookingConst.FIELD_BOOKING_ID);
            builder.Property(x => x.SalonServiceId).HasColumnName(BeautySalonServiceConst.FIELD_BEAUTY_SALON_SERVICE_ID);
            builder.Property(x => x.Count).HasColumnName(BookingConst.FIELD_BOOKING_COUNT);
 
            builder.HasMany(x => x.Times).WithMany(y => y.Bookings).UsingEntity<BookingTimes>(
               j => j
                   .HasOne(x => x.Time)
                   .WithMany()
                   .HasForeignKey(x => x.TimeId),
               j => j
                   .HasOne(x => x.Booking)
                   .WithMany()
                   .HasForeignKey(x => x.BookingId),
               j => 
               {
                   j.ToTable(BookingTimesConst.TABLE_NAME);
               });
        }
    }
}