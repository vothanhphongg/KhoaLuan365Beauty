using _365Beauty.Command.Domain.Constants.Bookings;
using _365Beauty.Command.Domain.Entities.Bookings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _365Beauty.Command.Persistence.Configurations.Bookings
{
    public class TimeConfig : IEntityTypeConfiguration<Time>
    {
        public void Configure(EntityTypeBuilder<Time> builder)
        {
            builder.ToTable(TimeConst.TABLE_NAME);

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName(TimeConst.FIELD_TIME_ID);
            builder.Property(x => x.Times).HasColumnName(TimeConst.FIELD_TIMES);
        }
    }
}