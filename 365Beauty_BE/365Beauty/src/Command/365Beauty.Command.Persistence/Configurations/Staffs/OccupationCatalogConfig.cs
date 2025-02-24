using _365Beauty.Command.Domain.Constants.Staffs;
using _365Beauty.Command.Domain.Entities.Staffs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _365Beauty.Command.Persistence.Configurations.Staffs
{
    internal class OccupationCatalogConfig : IEntityTypeConfiguration<OccupationCatalog>
    {
        public void Configure(EntityTypeBuilder<OccupationCatalog> builder)
        {
            builder.ToTable(OccupationCatalogConst.TABLE_NAME);
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName(OccupationCatalogConst.FIELD_OCCUPATION_ID);
            builder.Property(x => x.Name).HasColumnName(OccupationCatalogConst.FIELD_OCC_NAME);
        }
    }
}