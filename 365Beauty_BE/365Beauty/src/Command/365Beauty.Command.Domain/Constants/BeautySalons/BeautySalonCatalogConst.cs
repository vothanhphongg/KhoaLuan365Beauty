using _365Beauty.Contract.Enumerations;

namespace _365Beauty.Command.Domain.Constants.BeautySalons
{
    public class BeautySalonCatalogConst
    {
        #region Fields

        public const string TABLE_NAME = "beauty_salon_catalog";
        public const string FIELD_SALON_ID = "salon_id";
        public const string FIELD_SLN_CODE = "sln_code";
        public const string FIELD_SLN_NAME = "sln_name";
        public const string FIELD_SLN_DESCRIPTION = "sln_description";
        public const string FIELD_SLN_CONTENT = "sln_content";
        public const string FIELD_SLN_EMAIL = "sln_email";
        public const string FIELD_SLN_WEBSITE = "sln_website";
        public const string FIELD_SLN_TEL = "sln_tel";
        public const string FIELD_SLN_IMAGE = "sln_img";
        public const string FIELD_SLN_WORKING_DATE = "sln_working_date";
        public const string FIELD_SLN_ADDRESS = "sln_address";
        public const string FIELD_SLN_CREATED_DATE = "sln_created_date";
        public const string FIELD_SLN_UPDATED_DATE = "sln_updated_date";
        public const string FIELD_USER_ID_CREATED = "user_id_created";
        public const string FIELD_USER_ID_UPDATED = "user_id_updated";
        public const string FIELD_IS_ACTIVED = "is_actived";

        #endregion

        #region MaxLength

        public const int SLN_CODE_MAX_LENGTH = (int)MaxLength.MAX_32;
        public const int SLN_NAME_MAX_LENGTH = (int)MaxLength.MAX_256;
        public const int SLN_EMAIL_MAX_LENGTH = (int)MaxLength.MAX_64;
        public const int SLN_WEBSITE_MAX_LENGTH = (int)MaxLength.MAX_32;
        public const int SLN_TEL_MAX_LENGTH = (int)MaxLength.MAX_32;
        public const int SLN_IMAGE_MAX_LENGTH = (int)MaxLength.MAX_64;
        public const int SLN_WORKING_DATE_MAX_LENGTH = (int)MaxLength.MAX_512;
        public const int SLN_ADDRESS_MAX_LENGTH = (int)MaxLength.MAX_128;

        #endregion
    }
}
