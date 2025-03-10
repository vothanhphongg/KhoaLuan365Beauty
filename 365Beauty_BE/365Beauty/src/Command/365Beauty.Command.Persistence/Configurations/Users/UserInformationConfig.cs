using _365Beauty.Command.Domain.Constants.Users;
using _365Beauty.Command.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _365Beauty.Command.Persistence.Configurations.Users
{
    public class UserInformationConfig : IEntityTypeConfiguration<UserInformation>
    {
        public void Configure(EntityTypeBuilder<UserInformation> builder)
        {
            builder.ToTable(UserInformationConst.TABLE_NAME);

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName(UserInformationConst.FIELD_USER_INFORMATION_ID);
            builder.Property(x => x.FirstName).HasColumnName(UserInformationConst.FIELD_USER_INFORMATION_FIRST_NAME);
            builder.Property(x => x.LastName).HasColumnName(UserInformationConst.FIELD_USER_INFORMATION_LAST_NAME);
            builder.Property(x => x.Gender).HasColumnName(UserInformationConst.FIELD_USER_INFORMATION_GENDER);
            builder.Property(x => x.DateOfBirth).HasColumnName(UserInformationConst.FIELD_USER_INFORMATION_DATEOFBIRTH);
            builder.Property(x => x.Img).HasColumnName(UserInformationConst.FIELD_USER_INFORMATION_IMG);
            builder.Property(x => x.IdCard).HasColumnName(UserInformationConst.FIELD_USER_INFORMATION_ID_CARD);
            builder.Property(x => x.Email).HasColumnName(UserInformationConst.FIELD_USER_INFORMATION_EMAIL);
            builder.Property(x => x.Address).HasColumnName(UserInformationConst.FIELD_USER_INFORMATION_ADDRESS);
            builder.Property(x => x.WardId).HasColumnName(UserInformationConst.FIELD_USER_INFORMATION_WARD_ID);
            builder.Property(x => x.UpdatedDate).HasColumnName(UserInformationConst.FIELD_USER_INFORMATION_UPDATED_DATE);
            builder.Property(x => x.UserId).HasColumnName(UserAccountConst.FIELD_USER_ACCOUNT_ID);
        }
    }
}