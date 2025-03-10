using _365Beauty.Query.Domain.Constants.Staffs;
using _365Beauty.Query.Domain.Entities.Staffs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _365Beauty.Query.Persistence.Configurations.Staffs
{
    public class TitleCatalogConfig : IEntityTypeConfiguration<TitleCatalog>
    {
        public void Configure(EntityTypeBuilder<TitleCatalog> builder)
        {
            builder.ToTable(TitleCatalogConst.TABLE_NAME);

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName(TitleCatalogConst.FIELD_TITLE_ID);
            builder.Property(x => x.Name).HasColumnName(TitleCatalogConst.FIELD_TITLE_NAME);
        }
    }
}