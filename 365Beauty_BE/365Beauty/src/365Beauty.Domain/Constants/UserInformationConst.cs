using _365Beauty.Contract.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _365Beauty.Domain.Constants
{
    public class UserInformationConst
    {
        #region Fields

        public const string TABLE_USER_INFORMATION = "user_information";

        public const string FIELD_USER_INFORMATION_ID = "information_id";
        public const string FIELD_USER_INFORMATION_FIRST_NAME = "info_first_name";
        public const string FIELD_USER_INFORMATION_LAST_NAME = "info_last_name";
        public const string FIELD_USER_INFORMATION_GENDER = "info_gender";
        public const string FIELD_USER_INFORMATION_DATEOFBIRTH = "info_dateofbirth";
        public const string FIELD_USER_INFORMATION_IMG = "info_img";
        public const string FIELD_USER_INFORMATION_ID_CARD = "info_id_card";
        public const string FIELD_USER_INFORMATION_EMAIL = "info_email";
        public const string FIELD_USER_INFORMATION_ADDRESS = "info_address";
        public const string FIELD_USER_INFORMATION_WARD_ID = "ward_id";
        public const string FIELD_USER_INFORMATION_CREATED_DATE = "info_created_date";
        public const string FIELD_USER_INFORMATION_UPDATED_DATE = "info_updated_date";

        #endregion

        #region Maxlength

        public const int USER_INFORMATION_NUM_USER_MAX_LENGTH = (int)MaxLength.MAX_32;
        public const int USER_INFORMATION_FIRST_NAME_MAX_LENGTH = (int)MaxLength.MAX_64;
        public const int USER_INFORMATION_LAST_NAME_MAX_LENGTH = (int)MaxLength.MAX_64;
        public const int USER_INFORMATION_IMG_MAX_LENGTH = (int)MaxLength.MAX_64;
        public const int USER_INFORMATION_ID_CARD_MAX_LENGTH = (int)MaxLength.MAX_16;
        public const int USER_INFORMATION_NUM_INSURANCE_MAX_LENGTH = (int)MaxLength.MAX_32;
        public const int USER_INFORMATION_EMAIL_MAX_LENGTH = (int)MaxLength.MAX_64;
        public const int USER_INFORMATION_ADDRESS_MAX_LENGTH = (int)MaxLength.MAX_64;

        #endregion

    }
}
