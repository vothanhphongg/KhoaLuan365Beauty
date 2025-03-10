using _365Beauty.Query.Domain.Constants.Users;
using _365Beauty.Query.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _365Beauty.Query.Persistence.Configurations.Users
{
    public class UserAccountRoleConfig : IEntityTypeConfiguration<UserAccountRole>
    {
        public void Configure(EntityTypeBuilder<UserAccountRole> builder)
        {
            builder.ToTable(UserRoleConst.TABLE_ACCOUNT_ROLE);

            builder.HasKey(x => new { x.Id, x.RoleId });
            builder.Property(x => x.Id).HasColumnName(UserAccountConst.FIELD_USER_ACCOUNT_ID);
            builder.Property(x => x.RoleId).HasColumnName(UserRoleConst.FIELD_ROLE_ID);
        }
    }
}