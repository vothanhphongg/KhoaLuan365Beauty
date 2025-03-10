using _365Beauty.Query.Domain.Constants.Localizations;
using _365Beauty.Query.Domain.Entities.Localizations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _365Beauty.Query.Persistence.Configurations.Localizations
{
    public class WardConfig : IEntityTypeConfiguration<Ward>
    {
        public void Configure(EntityTypeBuilder<Ward> builder)
        {
            builder.ToTable(WardConst.TABLE_NAME);

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName(WardConst.FIELD_WARD_ID);
            builder.Property(x => x.Name).HasColumnName(WardConst.FIELD_WARD_NAME);
            builder.Property(x => x.DistrictId).HasColumnName(WardConst.FIELD_DISTRICT_ID);
        }
    }
}