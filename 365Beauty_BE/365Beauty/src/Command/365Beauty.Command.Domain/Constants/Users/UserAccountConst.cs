using _365Beauty.Contract.Enumerations;

namespace _365Beauty.Command.Domain.Constants.Users
{
    public class UserAccountConst
    {
        #region Fields

        public const string TABLE_NAME = "user_account";

        public const string FIELD_USER_ACCOUNT_ID = "user_id";
        public const string FIELD_USER_ACCOUNT_TEL = "user_tel";
        public const string FIELD_USER_ACCOUNT_PASSWORD = "user_password";
        public const string FIELD_USER_ACCOUNT_CREATED_DATE = "user_created_date";
        public const string FIELD_USER_ACCOUNT_IPADDRESS = "user_address";
        public const string FIELD_USER_ACCOUNT_TYPE = "user_type";
        public const string FIELD_USER_ACCOUNT_OTP = "user_otp";
        public const string FIELD_USER_ACCOUNT_IS_ACTIVED = "is_actived";

        #endregion

        #region Maxlength

        public const int USER_ACCOUNT_TEL_MAX_LENGTH = (int)MaxLength.MAX_32;
        public const int USER_ACCOUNT_PASSWORD_MAX_LENGTH = (int)MaxLength.MAX_256;
        public const int USER_ACCOUNT_ADDRESS_MAX_LENGTH = (int)MaxLength.MAX_32;
        public const int USER_ACCOUNT_OTP_MAX_LENGTH = (int)MaxLength.MAX_16;

        #endregion

        #region Message

        public const string CONFIRM_PASSWORD_NOT_MATCH = "ConfirmPassword does not match password";
        public const string TEL_IS_EXIST = "Tel already exists";
        public const string LOGIN_FAIL = "Login failed";

        #endregion
    }
}