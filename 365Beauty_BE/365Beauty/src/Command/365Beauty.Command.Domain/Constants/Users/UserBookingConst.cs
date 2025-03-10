namespace _365Beauty.Command.Domain.Constants.Users
{
    public class UserBookingConst
    {
        #region Fields

        public const string TABLE_NAME = "user_booking";

        public const string FIELD_USER_BOOKING_ID = "user_book_id";
        public const string FIELD_USER_BOOKING_DESCRIPTION = "user_booking_description";
        public const string FIELD_USER_BOOKING_DATE = "booking_date";
        public const string FIELD_USER_BOOKING_CREATED_DATE = "booking_created_date";
        public const string FIELD_USER_BOOKING_IS_ACTIVED = "is_actived";

        #endregion

        #region Booking Actived

        public const int NOT_CONFIRM = 0; // chưa xác nhận
        public const int CONFIRMED = 1; // đã xác nhận
        public const int SUCCESSED = 2; // đã thành công
        public const int CANCEL = 3; // hủy lịch

        #endregion
    }
}