using _365Beauty.Domain.Constants;
using _365Beauty.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _365Beauty.Command.Persistence.Configurations
{
    public class UserAccountConfig : IEntityTypeConfiguration<UserAccount>
    {
        public void Configure(EntityTypeBuilder<UserAccount> builder)
        {
            builder.ToTable(UserAccountConst.TABLE_USER_ACCOUNT);
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName(UserAccountConst.FIELD_USER_ACCOUNT_ID);
            builder.Property(x => x.Tel).HasColumnName(UserAccountConst.FIELD_USER_ACCOUNT_TEL).HasMaxLength(UserAccountConst.USER_ACCOUNT_TEL_MAX_LENGTH);
            builder.Property(x => x.Password).HasColumnName(UserAccountConst.FIELD_USER_ACCOUNT_PASSWORD).HasMaxLength(UserAccountConst.USER_ACCOUNT_PASSWORD_MAX_LENGTH);
            builder.Property(x => x.CreatedDate).HasColumnName(UserAccountConst.FIELD_USER_ACCOUNT_CREATED_DATE);
            builder.Property(x => x.Type).HasColumnName(UserAccountConst.FIELD_USER_ACCOUNT_TYPE);
            builder.Property(x => x.Otp).HasColumnName(UserAccountConst.FIELD_USER_ACCOUNT_OTP).HasMaxLength(UserAccountConst.USER_ACCOUNT_OTP_MAX_LENGTH);
            builder.Property(x => x.IsActived).HasColumnName(UserAccountConst.FIELD_USER_ACCOUNT_IS_ACTIVED);

            builder.HasOne(x => x.userInformation).WithOne(x => x.userAccount).HasForeignKey<UserInformation>(x => x.UserId);
        }
    }
}