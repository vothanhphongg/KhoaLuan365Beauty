using _365Beauty.Contract.Enumerations;

namespace _365Beauty.Command.Domain.Constants.Staffs
{
    public class StaffCatalogConst
    {
        #region Fields

        public const string TABLE_NAME = "staff_catalog";

        public const string FIELD_STAFF_ID = "staff_id";
        public const string FIELD_STAFF_CODE = "staff_code";
        public const string FIELD_STAFF_ID_CARD = "staff_id_card";
        public const string FIELD_STAFF_FULLNAME = "staff_fullname";
        public const string FIELD_STAFF_GENDER = "staff_gender";
        public const string FIELD_STAFF_DATEOFBIRTH = "staff_dateofbirth";
        public const string FIELD_STAFF_EMAIL = "staff_email";
        public const string FIELD_STAFF_TEL = "staff_tel";
        public const string FIELD_STAFF_INTRODUCTION = "staff_introduction";
        public const string FIELD_STAFF_CATALOG_IMG = "staff_img";
        public const string FIELD_STAFF_CATALOG_ADDRESS = "staff_address";
        public const string FIELD_STAFF_CATALOG_IS_ACTIVED = "is_actived";

        #endregion

        #region MaxLength
        
        public const int STAFF_CATALOG_CODE_MAX_LENGTH = (int)MaxLength.MAX_32;
        public const int STAFF_CATALOG_ID_CARD_MAX_LENGTH = (int)MaxLength.MAX_15;
        public const int STAFF_CATALOG_FULLNAME_MAX_LENGTH = (int)MaxLength.MAX_128;
        public const int STAFF_CATALOG_EMAIL_MAX_LENGTH = (int)MaxLength.MAX_64;
        public const int STAFF_CATALOG_TEL_MAX_LENGTH = (int)MaxLength.MAX_32;
        public const int STAFF_CATALOG_TEL_OTHER_MAX_LENGTH = (int)MaxLength.MAX_64;
        public const int STAFF_CATALOG_INTRODUCTION_MAX_LENGTH = (int)MaxLength.MAX_512;
        public const int STAFF_CATALOG_IMG_MAX_LENGTH = (int)MaxLength.MAX_64;
        public const int STAFF_CATALOG_ADDRESS_MAX_LENGTH = (int)MaxLength.MAX_128;

        #endregion

        #region Message

        public const string FOREIGN_KEY_EXISTS = "StaffCatalog cannot be deleted because it is being referenced by another entity.";

        #endregion
    }
}