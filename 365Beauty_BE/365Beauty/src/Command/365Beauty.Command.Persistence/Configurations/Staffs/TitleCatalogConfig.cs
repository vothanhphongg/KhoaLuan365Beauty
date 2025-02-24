using _365Beauty.Command.Domain.Constants.Staffs;
using _365Beauty.Command.Domain.Entities.Staffs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _365Beauty.Command.Persistence.Configurations.Staffs
{
    public class TitleCatalogConfig : IEntityTypeConfiguration<TitleCatalog>
    {
        public void Configure(EntityTypeBuilder<TitleCatalog> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName(TitleCatalogConst.FIELD_TITLE_ID);
            builder.Property(x => x.Name).HasColumnName(TitleCatalogConst.FIELD_TITLE_NAME);
            builder.ToTable(TitleCatalogConst.TABLE_NAME);
        }
    }
}