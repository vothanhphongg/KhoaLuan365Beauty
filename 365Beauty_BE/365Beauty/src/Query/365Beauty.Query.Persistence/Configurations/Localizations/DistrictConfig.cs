using _365Beauty.Query.Domain.Constants.Localizations;
using _365Beauty.Query.Domain.Entities.Localizations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _365Beauty.Query.Persistence.Configurations.Localizations
{
    public class DistrictConfig : IEntityTypeConfiguration<District>
    {
        public void Configure(EntityTypeBuilder<District> builder)
        {
            builder.ToTable(DistrictConst.TABLE_NAME);

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName(DistrictConst.FIELD_DISTRICT_ID);
            builder.Property(x => x.Name).HasColumnName(DistrictConst.FIELD_DISTRICT_NAME);
            builder.Property(x => x.ProvinceId).HasColumnName(DistrictConst.FIELD_PROVINCE_ID);

            builder.HasMany(x => x.Wards).WithOne().HasForeignKey(x => x.DistrictId);
        }
    }
}