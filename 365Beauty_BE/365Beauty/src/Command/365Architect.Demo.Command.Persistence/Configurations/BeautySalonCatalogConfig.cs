using _365Beauty.Domain.Constants;
using _365Beauty.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _365Beauty.Command.Persistence.Configurations
{
    public class BeautySalonCatalogConfig : IEntityTypeConfiguration<BeautySalonCatalog>
    {
        public void Configure(EntityTypeBuilder<BeautySalonCatalog> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName(BeautySalonCatalogConst.FIELD_SALON_ID);
            builder.Property(x => x.Code).HasColumnName(BeautySalonCatalogConst.FIELD_SLN_CODE).HasMaxLength(BeautySalonCatalogConst.SLN_CODE_MAX_LENGTH);
            builder.Property(x => x.Name).HasColumnName(BeautySalonCatalogConst.FIELD_SLN_NAME).IsRequired().HasMaxLength(BeautySalonCatalogConst.SLN_NAME_MAX_LENGTH);
            builder.Property(x => x.Description).HasColumnName(BeautySalonCatalogConst.FIELD_SLN_DESCRIPTION).HasMaxLength(BeautySalonCatalogConst.SLN_DESCRIPTION_MAX_LENGTH);
            builder.Property(x => x.Content).HasColumnName(BeautySalonCatalogConst.FIELD_SLN_CONTENT);
            builder.Property(x => x.Email).HasColumnName(BeautySalonCatalogConst.FIELD_SLN_EMAIL).IsRequired().HasMaxLength(BeautySalonCatalogConst.SLN_EMAIL_MAX_LENGTH);
            builder.Property(x => x.Website).HasColumnName(BeautySalonCatalogConst.FIELD_SLN_WEBSITE).HasMaxLength(BeautySalonCatalogConst.SLN_WEBSITE_MAX_LENGTH);
            builder.Property(x => x.Tel).HasColumnName(BeautySalonCatalogConst.FIELD_SLN_TEL).IsRequired().HasMaxLength(BeautySalonCatalogConst.SLN_TEL_MAX_LENGTH);
            builder.Property(x => x.Image).HasColumnName(BeautySalonCatalogConst.FIELD_SLN_IMAGE).HasMaxLength(BeautySalonCatalogConst.SLN_IMAGE_MAX_LENGTH);
            builder.Property(x => x.WorkingDate).HasColumnName(BeautySalonCatalogConst.FIELD_SLN_WORKING_DATE).HasMaxLength(BeautySalonCatalogConst.SLN_WORKING_DATE_MAX_LENGTH);
            builder.Property(x => x.Address).HasColumnName(BeautySalonCatalogConst.FIELD_SLN_ADDRESS).HasMaxLength(BeautySalonCatalogConst.SLN_ADDRESS_MAX_LENGTH);
            builder.Property(x => x.WardId).HasColumnName(BeautySalonCatalogConst.FIELD_WARD_ID).IsRequired();
            builder.Property(x => x.CreatedDate).HasColumnName(BeautySalonCatalogConst.FIELD_SLN_CREATED_DATE).IsRequired();
            builder.Property(x => x.UpdatedDate).HasColumnName(BeautySalonCatalogConst.FIELD_SLN_UPDATED_DATE);
            builder.Property(x => x.UserIdCreated).HasColumnName(BeautySalonCatalogConst.FIELD_USER_ID_CREATED);
            builder.Property(x => x.UserIdUpdated).HasColumnName(BeautySalonCatalogConst.FIELD_USER_ID_UPDATED);
            builder.Property(x => x.IsActived).HasColumnName(BeautySalonCatalogConst.FIELD_IS_ACTIVED).IsRequired();
            // Configuring relationships
           
            builder.ToTable(BeautySalonCatalogConst.TABLE_NAME);
        }
    }
}