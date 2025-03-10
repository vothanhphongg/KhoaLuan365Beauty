using _365Beauty.Query.Domain.Constants.Localizations;
using _365Beauty.Query.Domain.Entities.Localizations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _365Beauty.Query.Persistence.Configurations.Localizations
{
    public class ProvinceConfig : IEntityTypeConfiguration<Province>
    {
        public void Configure(EntityTypeBuilder<Province> builder)
        {
            builder.ToTable(ProvinceConst.TABLE_NAME);

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName(ProvinceConst.FIELD_DISTRICT_ID);
            builder.Property(x => x.Name).HasColumnName(ProvinceConst.FIELD_DISTRICT_NAME);

            builder.HasMany(x => x.Districts).WithOne().HasForeignKey(x => x.ProvinceId);
        }
    }
}