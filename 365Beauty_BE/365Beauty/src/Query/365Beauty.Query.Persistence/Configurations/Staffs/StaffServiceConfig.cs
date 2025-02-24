using _365Beauty.Query.Domain.Constants.Services;
using _365Beauty.Query.Domain.Constants.Staffs;
using _365Beauty.Query.Domain.Entities.Staffs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _365Beauty.Query.Persistence.Configurations.Staffs
{
    public class StaffServiceConfig : IEntityTypeConfiguration<StaffService>
    {
        public void Configure(EntityTypeBuilder<StaffService> builder)
        {
            builder.ToTable(StaffServiceConst.TABLE_NAME);
            builder.HasKey(x => new { x.StaffId, x.ServiceId });
            builder.Property(x => x.StaffId).HasColumnName(StaffCatalogConst.FIELD_STAFF_ID);
            builder.Property(x => x.ServiceId).HasColumnName(ServiceCatalogConst.FIELD_SERVICE_ID);
        }
    }
}