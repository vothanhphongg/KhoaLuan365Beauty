using _365Beauty.Query.Domain.Constants.Staffs;
using _365Beauty.Query.Domain.Entities.Staffs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _365Beauty.Query.Persistence.Configurations.Staffs
{
    public class DegreeCatalogConfig : IEntityTypeConfiguration<DegreeCatalog>
    {
        public void Configure(EntityTypeBuilder<DegreeCatalog> builder)
        {
            builder.ToTable(DegreeCatalogConst.TABLE_NAME);

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName(DegreeCatalogConst.FIELD_DEGREE_ID);
            builder.Property(x => x.Name).HasColumnName(DegreeCatalogConst.FIELD_DEG_NAME);
        }
    }
}