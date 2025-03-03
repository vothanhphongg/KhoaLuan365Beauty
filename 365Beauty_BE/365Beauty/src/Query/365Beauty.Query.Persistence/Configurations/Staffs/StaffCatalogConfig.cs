using _365Beauty.Query.Domain.Constants.BeautySalons;
using _365Beauty.Query.Domain.Constants.Staffs;
using _365Beauty.Query.Domain.Entities.Staffs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _365Beauty.Query.Persistence.Configurations.Staffs
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
            builder.Property(x => x.Introduction).HasColumnName(StaffCatalogConst.FIELD_STAFF_INTRODUCTION);
            builder.Property(x => x.Img).HasColumnName(StaffCatalogConst.FIELD_STAFF_CATALOG_IMG);
            builder.Property(x => x.SalonId).HasColumnName(BeautySalonCatalogConst.FIELD_SALON_ID);
            builder.Property(x => x.DegreeId).HasColumnName(DegreeCatalogConst.FIELD_DEGREE_ID);
            builder.Property(x => x.TitleId).HasColumnName(TitleCatalogConst.FIELD_TITLE_ID);
            builder.Property(x => x.OccupationId).HasColumnName(OccupationCatalogConst.FIELD_OCCUPATION_ID);
            builder.Property(x => x.Address).HasColumnName(StaffCatalogConst.FIELD_STAFF_CATALOG_ADDRESS);
            builder.Property(x => x.WardId).HasColumnName(StaffCatalogConst.FIELD_STAFF_WARD_ID);
            builder.Property(x => x.IsActived).HasColumnName(StaffCatalogConst.FIELD_STAFF_CATALOG_IS_ACTIVED);

            builder.HasMany(x => x.ServiceCatalogs)
           .WithMany(y => y.StaffCatalogs)
           .UsingEntity<StaffService>(
               j => j
                   .HasOne(x => x.ServiceCatalog)
                   .WithMany()
                   .HasForeignKey(x => x.ServiceId),
               j => j
                   .HasOne(x => x.StaffCatalog)
                   .WithMany()
                   .HasForeignKey(x => x.StaffId),
               j =>
               {
                   j.ToTable(StaffServiceConst.TABLE_NAME);
               });
        }
    }
}