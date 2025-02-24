using _365Beauty.Command.Domain.Constants.Users;
using _365Beauty.Command.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Configurations.Users
{
    public class UserRoleConfig : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.ToTable(UserRoleConst.TABLE_ROLE);
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName(UserRoleConst.FIELD_ROLE_ID);
            builder.Property(x => x.Name).HasColumnName(UserRoleConst.FIELD_ROLE_NAME);
        }
    }
}