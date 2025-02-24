using _365Beauty.Command.Domain.Constants.Localizations;
using _365Beauty.Command.Domain.Entities.Localizations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Configurations.Localizations
{
    public class WardConfig : IEntityTypeConfiguration<Ward>
    {
        public void Configure(EntityTypeBuilder<Ward> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName(WardConst.FIELD_WARD_ID);
            builder.Property(x => x.Name).HasColumnName(WardConst.FIELD_WARD_NAME);
            builder.Property(x => x.DistrictId).HasColumnName(WardConst.FIELD_DISTRICT_ID);

            builder.ToTable(WardConst.TABLE_NAME);
        }
    }
}