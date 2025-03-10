namespace _365Beauty.Query.Domain.Constants.Users
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

        public const string STRING_NOT_CONFIRM = "Chưa xác nhận lịch hẹn"; // chưa xác nhận
        public const string STRING_CANCEL = "Hủy lịch hẹn";
        public const string STRING_CONFIRMED = "Đã xác nhận lịch hẹn"; // đã xác nhận
        public const string STRING_SUCCESSED = "Xác nhận hoàn thành và đánh giá"; // đã thành công
        public const string STRING_CANCELED = "Đã hủy lịch hẹn"; // hủy lịch
        #endregion
    }
}