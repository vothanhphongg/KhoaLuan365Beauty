using _365Beauty.Query.Domain.Constants.BeautySalons;
using _365Beauty.Query.Domain.Entities.BeautySalons;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _365Beauty.Query.Persistence.Configurations.BeautySalons
{
    public class BeautySalonImageConfig : IEntityTypeConfiguration<BeautySalonImage>
    {
        public void Configure(EntityTypeBuilder<BeautySalonImage> builder)
        {
            builder.ToTable(BeautySalonImageConst.TABLE_NAME);

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName(BeautySalonImageConst.FIELD_IMAGE_ID);
            builder.Property(x => x.SalonId).HasColumnName(BeautySalonCatalogConst.FIELD_SALON_ID);
            builder.Property(x => x.ImageUrl).HasColumnName(BeautySalonImageConst.FIELD_IMAGE_URL);
        }
    }
}