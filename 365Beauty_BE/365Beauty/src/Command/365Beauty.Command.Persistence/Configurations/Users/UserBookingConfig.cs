﻿using _365Beauty.Command.Domain.Constants.BeautySalons;
using _365Beauty.Command.Domain.Constants.Bookings;
using _365Beauty.Command.Domain.Constants.Staffs;
using _365Beauty.Command.Domain.Constants.Users;
using _365Beauty.Command.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _365Beauty.Command.Persistence.Configurations.Users
{
    public class UserBookingConfig : IEntityTypeConfiguration<UserBooking>
    {
        public void Configure(EntityTypeBuilder<UserBooking> builder)
        {
            builder.ToTable(UserBookingConst.TABLE_NAME);

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName(UserBookingConst.FIELD_USER_BOOKING_ID);
            builder.Property(x => x.SalonServiceId).HasColumnName(BeautySalonServiceConst.FIELD_BEAUTY_SALON_SERVICE_ID);
            builder.Property(x => x.UserId).HasColumnName(UserAccountConst.FIELD_USER_ACCOUNT_ID);
            builder.Property(x => x.StaffId).HasColumnName(StaffCatalogConst.FIELD_STAFF_ID);
            builder.Property(x => x.TimeId).HasColumnName(TimeConst.FIELD_TIME_ID);
            builder.Property(x => x.BookingTypeId).HasColumnName(BookingTypeConst.FIELD_BOOKING_TYPE_ID);
            builder.Property(x => x.Description).HasColumnName(UserBookingConst.FIELD_USER_BOOKING_DESCRIPTION);
            builder.Property(x => x.BookingDate).HasColumnName(UserBookingConst.FIELD_USER_BOOKING_DATE);
            builder.Property(x => x.CreateDate).HasColumnName(UserBookingConst.FIELD_USER_BOOKING_CREATED_DATE);
            builder.Property(x => x.IsActived).HasColumnName(UserBookingConst.FIELD_USER_BOOKING_IS_ACTIVED);
        }
    }
}