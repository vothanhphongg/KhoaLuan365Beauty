using _365Beauty.Command.Domain.Constants.BeautySalons;
using _365Beauty.Command.Domain.Constants.Users;
using _365Beauty.Command.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _365Beauty.Command.Persistence.Configurations.Users
{
    public class UserRatingConfig : IEntityTypeConfiguration<UserRating>
    {
        public void Configure(EntityTypeBuilder<UserRating> builder)
        {
            builder.ToTable(UserRatingConst.TABLE_NAME);

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName(UserRatingConst.FIELD_RATING_ID);
            builder.Property(x => x.UserId).HasColumnName(UserAccountConst.FIELD_USER_ACCOUNT_ID);
            builder.Property(x => x.SalonServiceId).HasColumnName(BeautySalonServiceConst.FIELD_BEAUTY_SALON_SERVICE_ID);
            builder.Property(x => x.Comment).HasColumnName(UserRatingConst.FIELD_RATING_COMMENT);
            builder.Property(x => x.Count).HasColumnName(UserRatingConst.FIELD_RATING_COUNT);
            builder.Property(x => x.CreatedDate).HasColumnName(UserRatingConst.FIELD_RATING_CREATED_DATE);           
        }
    }
}