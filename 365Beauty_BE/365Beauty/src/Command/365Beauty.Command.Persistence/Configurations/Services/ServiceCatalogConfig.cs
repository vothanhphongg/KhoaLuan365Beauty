using _365Beauty.Command.Domain.Constants.Services;
using _365Beauty.Command.Domain.Entities.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Configurations.Services
{
    public class ServiceCatalogConfig : IEntityTypeConfiguration<ServiceCatalog>
    {
        public void Configure(EntityTypeBuilder<ServiceCatalog> builder)
        {
            builder.ToTable(ServiceCatalogConst.TABLE_NAME);
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName(ServiceCatalogConst.FIELD_SERVICE_ID);
            builder.Property(x => x.Name).HasColumnName(ServiceCatalogConst.FIELD_SER_NAME);
            builder.Property(x => x.Icon).HasColumnName(ServiceCatalogConst.FIELD_SER_ICON);
            builder.Property(x => x.CreatedDate).HasColumnName(ServiceCatalogConst.FIELD_SER_CREATED_DATE);
            builder.Property(x => x.UserIdCreated).HasColumnName(ServiceCatalogConst.FIELD_USER_ID_CREATED);
            builder.Property(x => x.IsActived).HasColumnName(ServiceCatalogConst.FIELD_IS_ACTIVED);
        }
    }
}