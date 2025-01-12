using _365Beauty.Domain.Constants;
using _365Beauty.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _365Beauty.Command.Persistence.Configurations
{
    public class UserInformationConfig : IEntityTypeConfiguration<UserInformation>
    {
        public void Configure(EntityTypeBuilder<UserInformation> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName(UserInformationConst.FIELD_USER_INFORMATION_ID);
            builder.Property(x => x.FirstName).HasColumnName(UserInformationConst.FIELD_USER_INFORMATION_FIRST_NAME).HasMaxLength(UserInformationConst.USER_INFORMATION_FIRST_NAME_MAX_LENGTH);
            builder.Property(x => x.LastName).HasColumnName(UserInformationConst.FIELD_USER_INFORMATION_LAST_NAME).HasMaxLength(UserInformationConst.USER_INFORMATION_LAST_NAME_MAX_LENGTH);
            builder.Property(x => x.Gender).HasColumnName(UserInformationConst.FIELD_USER_INFORMATION_GENDER);
            builder.Property(x => x.DateOfBirth).HasColumnName(UserInformationConst.FIELD_USER_INFORMATION_DATEOFBIRTH);
            builder.Property(x => x.Img).HasColumnName(UserInformationConst.FIELD_USER_INFORMATION_IMG).HasMaxLength(UserInformationConst.USER_INFORMATION_IMG_MAX_LENGTH);
            builder.Property(x => x.IdCard).HasColumnName(UserInformationConst.FIELD_USER_INFORMATION_ID_CARD).HasMaxLength(UserInformationConst.USER_INFORMATION_ID_CARD_MAX_LENGTH);
            builder.Property(x => x.Email).HasColumnName(UserInformationConst.FIELD_USER_INFORMATION_EMAIL).HasMaxLength(UserInformationConst.USER_INFORMATION_EMAIL_MAX_LENGTH);
            builder.Property(x => x.Address).HasColumnName(UserInformationConst.FIELD_USER_INFORMATION_ADDRESS).HasMaxLength(UserInformationConst.USER_INFORMATION_ADDRESS_MAX_LENGTH);
            builder.Property(x => x.WardId).HasColumnName(UserInformationConst.FIELD_USER_INFORMATION_WARD_ID);
            builder.Property(x => x.CreatedDate).HasColumnName(UserInformationConst.FIELD_USER_INFORMATION_CREATED_DATE);
            builder.Property(x => x.UpdatedDate).HasColumnName(UserInformationConst.FIELD_USER_INFORMATION_UPDATED_DATE);
            builder.Property(x => x.UserId).HasColumnName(UserAccountConst.FIELD_USER_ACCOUNT_ID);
            builder.ToTable(UserInformationConst.TABLE_USER_INFORMATION);
        }
    }
}