using _365Beauty.Contract.Enumerations;

namespace _365Beauty.Command.Domain.Constants.Users
{
    public class UserRoleConst
    {
        #region Fields

        public const string TABLE_NAME = "user_role";
        public const string TABLE_ACCOUNT_ROLE = "user_account_roles";

        public const string FIELD_ROLE_ID = "role_id";
        public const string FIELD_ROLE_NAME = "role_name";

        #endregion

        #region Maxlength

        public const int ROLE_NAME_MAX_LENGTH = (int)MaxLength.MAX_32;

        #endregion
    }
}