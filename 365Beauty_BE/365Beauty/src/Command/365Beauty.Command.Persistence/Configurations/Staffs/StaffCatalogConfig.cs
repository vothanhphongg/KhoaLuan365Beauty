using _365Beauty.Command.Domain.Constants.BeautySalons;
using _365Beauty.Command.Domain.Constants.Localizations;
using _365Beauty.Command.Domain.Constants.Staffs;
using _365Beauty.Command.Domain.Entities.Staffs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _365Beauty.Command.Persistence.Configurations.Staffs
{
    public class StaffCatalogConfig : IEntityTypeConfiguration<StaffCatalog>
    {
        public void Configure(EntityTypeBuilder<StaffCatalog> builder)
        {
            builder.ToTable(StaffCatalogConst.TABLE_NAME);
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName(StaffCatalogConst.FIELD_STAFF_ID);
            builder.Property(x => x.Code).HasColumnName(StaffCatalogConst.FIELD_STAFF_CODE);
            builder.Property(x => x.IdCard).HasColumnName(StaffCatalogConst.FIELD_STAFF_ID_CARD);
            builder.Property(x => x.FullName).HasColumnName(StaffCatalogConst.FIELD_STAFF_FULLNAME);
            builder.Property(x => x.Gender).HasColumnName(StaffCatalogConst.FIELD_STAFF_GENDER);
            builder.Property(x => x.DateOfBirth).HasColumnName(StaffCatalogConst.FIELD_STAFF_DATEOFBIRTH);
            builder.Property(x => x.Email).HasColumnName(StaffCatalogConst.FIELD_STAFF_EMAIL);
            builder.Property(x => x.Tel).HasColumnName(StaffCatalogConst.FIELD_STAFF_TEL);
            builder.Property(x => x.TelOther).HasColumnName(StaffCatalogConst.FIELD_STAFF_TEL_OTHER);
            builder.Property(x => x.Introduction).HasColumnName(StaffCatalogConst.FIELD_STAFF_INTRODUCTION);
            builder.Property(x => x.Content).HasColumnName(StaffCatalogConst.FIELD_STAFF_CATALOG_CONTENT);
            builder.Property(x => x.Img).HasColumnName(StaffCatalogConst.FIELD_STAFF_CATALOG_IMG);
            builder.Property(x => x.SalonId).HasColumnName(BeautySalonCatalogConst.FIELD_SALON_ID);
            builder.Property(x => x.DegreeId).HasColumnName(DegreeCatalogConst.FIELD_DEGREE_ID);
            builder.Property(x => x.TitleId).HasColumnName(TitleCatalogConst.FIELD_TITLE_ID);
            builder.Property(x => x.OccupationId).HasColumnName(OccupationCatalogConst.FIELD_OCCUPATION_ID);
            builder.Property(x => x.Address).HasColumnName(StaffCatalogConst.FIELD_STAFF_CATALOG_ADDRESS);
            builder.Property(x => x.WardId).HasColumnName(WardConst.FIELD_FK_WARD_ID);
            builder.Property(x => x.CreatedDate).HasColumnName(StaffCatalogConst.FIELD_STAFF_CATALOG_CREATED_DATE);
            builder.Property(x => x.UpdatedDate).HasColumnName(StaffCatalogConst.FIELD_STAFF_CATALOG_UPDATED_DATE);
            builder.Property(x => x.UserIdUpdated).HasColumnName(StaffCatalogConst.FIELD_USER_ID_UPDATED);
            builder.Property(x => x.IsActived).HasColumnName(StaffCatalogConst.FIELD_STAFF_CATALOG_IS_ACTIVED);

            builder.HasMany(x => x.StaffServices).WithOne().HasForeignKey(x => x.StaffId);
        }
    }
}