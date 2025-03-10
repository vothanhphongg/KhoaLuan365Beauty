using _365Beauty.Query.Domain.Constants.BeautySalons;
using _365Beauty.Query.Domain.Constants.Services;
using _365Beauty.Query.Domain.Entities.BeautySalons;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _365Beauty.Query.Persistence.Configurations.BeautySalons
{
    public class BeautySalonServiceConfig : IEntityTypeConfiguration<BeautySalonService>
    {
        public void Configure(EntityTypeBuilder<BeautySalonService> builder)
        {
            builder.ToTable(BeautySalonServiceConst.TABLE_NAME);

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName(BeautySalonServiceConst.FIELD_BEAUTY_SALON_SERVICE_ID);
            builder.Property(x => x.SalonId).HasColumnName(BeautySalonCatalogConst.FIELD_SALON_ID);
            builder.Property(x => x.ServiceId).HasColumnName(ServiceCatalogConst.FIELD_SERVICE_ID);
            builder.Property(x => x.Name).HasColumnName(BeautySalonServiceConst.FIELD_SS_NAME);
            builder.Property(x => x.Description).HasColumnName(BeautySalonServiceConst.FIELD_SS_DESCRIPTION);
            builder.Property(x => x.Image).HasColumnName(BeautySalonServiceConst.FIELD_SS_IMAGE);
            builder.Property(x => x.CreatedDate).HasColumnName(BeautySalonServiceConst.FIELD_SS_CREATED_DATE);
            builder.Property(x => x.IsActived).HasColumnName(BeautySalonServiceConst.FIELD_IS_ACTIVED);

            builder.HasOne(x => x.Price).WithOne().HasForeignKey<Price>(x => x.SalonServiceId);
            builder.HasOne(x => x.SalonCatalog).WithMany(y => y.BeautySalonServices).HasForeignKey(x => x.SalonId);
            builder.HasOne(x => x.ServiceCatalog).WithMany(y => y.BeautySalonServices).HasForeignKey(x => x.ServiceId);
        }
    }
}