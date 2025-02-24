using _365Beauty.Contract.Enumerations;

namespace _365Beauty.Command.Domain.Constants.Services
{
    public class ServiceCatalogConst
    {
        #region Fields

        public const string TABLE_NAME = "service_catalog";
        public const string FIELD_SERVICE_ID = "service_id";
        public const string FIELD_SER_NAME = "ser_name";
        public const string FIELD_SER_ICON = "ser_icon";
        public const string FIELD_SER_CREATED_DATE = "ser_created_date";
        public const string FIELD_USER_ID_CREATED = "user_id_created";
        public const string FIELD_IS_ACTIVED = "is_actived";

        #endregion

        #region MaxLength

        public const int SER_NAME_MAX_LENGTH = (int)MaxLength.MAX_256;
        public const int SER_ICON_MAX_LENGTH = (int)MaxLength.MAX_128;

        #endregion
    }
}