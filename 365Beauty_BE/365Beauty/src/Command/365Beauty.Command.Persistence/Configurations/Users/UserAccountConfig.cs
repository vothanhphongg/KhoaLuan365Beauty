using _365Beauty.Command.Domain.Constants.Users;
using _365Beauty.Command.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Configurations.Users
{
    public class UserAccountConfig : IEntityTypeConfiguration<UserAccount>
    {
        public void Configure(EntityTypeBuilder<UserAccount> builder)
        {
            builder.ToTable(UserAccountConst.TABLE_USER_ACCOUNT);
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName(UserAccountConst.FIELD_USER_ACCOUNT_ID);
            builder.Property(x => x.Tel).HasColumnName(UserAccountConst.FIELD_USER_ACCOUNT_TEL);
            builder.Property(x => x.Password).HasColumnName(UserAccountConst.FIELD_USER_ACCOUNT_PASSWORD);
            builder.Property(x => x.CreatedDate).HasColumnName(UserAccountConst.FIELD_USER_ACCOUNT_CREATED_DATE);
            builder.Property(x => x.Otp).HasColumnName(UserAccountConst.FIELD_USER_ACCOUNT_OTP);
            builder.Property(x => x.IsActived).HasColumnName(UserAccountConst.FIELD_USER_ACCOUNT_IS_ACTIVED);

            builder.HasOne(x => x.UserInformation).WithOne().HasForeignKey<UserInformation>(x => x.UserId);
            builder.HasMany(x => x.UserAccountRoles).WithOne().HasForeignKey(x => x.Id);
        }
    }
}