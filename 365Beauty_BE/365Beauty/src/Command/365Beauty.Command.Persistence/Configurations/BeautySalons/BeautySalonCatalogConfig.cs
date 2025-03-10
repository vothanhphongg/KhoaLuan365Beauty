using _365Beauty.Command.Domain.Constants.BeautySalons;
using _365Beauty.Command.Domain.Constants.Localizations;
using _365Beauty.Command.Domain.Entities.BeautySalons;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _365Beauty.Command.Persistence.Configurations.BeautySalons
{
    public class BeautySalonCatalogConfig : IEntityTypeConfiguration<BeautySalonCatalog>
    {
        public void Configure(EntityTypeBuilder<BeautySalonCatalog> builder)
        {
            builder.ToTable(BeautySalonCatalogConst.TABLE_NAME);

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName(BeautySalonCatalogConst.FIELD_SALON_ID);
            builder.Property(x => x.Code).HasColumnName(BeautySalonCatalogConst.FIELD_SLN_CODE);
            builder.Property(x => x.Name).HasColumnName(BeautySalonCatalogConst.FIELD_SLN_NAME);
            builder.Property(x => x.Description).HasColumnName(BeautySalonCatalogConst.FIELD_SLN_DESCRIPTION);
            builder.Property(x => x.Email).HasColumnName(BeautySalonCatalogConst.FIELD_SLN_EMAIL);
            builder.Property(x => x.Website).HasColumnName(BeautySalonCatalogConst.FIELD_SLN_WEBSITE);
            builder.Property(x => x.Tel).HasColumnName(BeautySalonCatalogConst.FIELD_SLN_TEL);
            builder.Property(x => x.Image).HasColumnName(BeautySalonCatalogConst.FIELD_SLN_IMAGE);
            builder.Property(x => x.WorkingDate).HasColumnName(BeautySalonCatalogConst.FIELD_SLN_WORKING_DATE);
            builder.Property(x => x.Address).HasColumnName(BeautySalonCatalogConst.FIELD_SLN_ADDRESS);
            builder.Property(x => x.WardId).HasColumnName(WardConst.FIELD_FK_WARD_ID);
            builder.Property(x => x.CreatedDate).HasColumnName(BeautySalonCatalogConst.FIELD_SLN_CREATED_DATE);
            builder.Property(x => x.UpdatedDate).HasColumnName(BeautySalonCatalogConst.FIELD_SLN_UPDATED_DATE);
            builder.Property(x => x.UserIdCreated).HasColumnName(BeautySalonCatalogConst.FIELD_USER_ID_CREATED);
            builder.Property(x => x.UserIdUpdated).HasColumnName(BeautySalonCatalogConst.FIELD_USER_ID_UPDATED);
            builder.Property(x => x.IsActived).HasColumnName(BeautySalonCatalogConst.FIELD_IS_ACTIVED);

            builder.HasMany(x => x.BeautySalonServices).WithOne().HasForeignKey(x => x.SalonId);
            builder.HasMany(x => x.BeautySalonImages).WithOne().HasForeignKey(x => x.SalonId);
        }
    }
}