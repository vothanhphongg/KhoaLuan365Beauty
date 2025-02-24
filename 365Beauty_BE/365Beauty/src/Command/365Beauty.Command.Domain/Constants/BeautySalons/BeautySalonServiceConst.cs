using _365Beauty.Contract.Enumerations;

namespace _365Beauty.Command.Domain.Constants.BeautySalons
{
    public class BeautySalonServiceConst
    {
        #region Fields

        public const string TABLE_NAME = "beauty_salon_services";
        public const string FIELD_BEAUTY_SALON_SERVICE_ID = "ss_id";
        public const string FIELD_SS_NAME = "ss_name";
        public const string FIELD_SS_DESCRIPTION = "ss_description";
        public const string FIELD_SS_IMAGE = "ss_img";
        public const string FIELD_SS_CREATED_DATE = "ss_created_date";
        public const string FIELD_IS_ACTIVED = "is_actived";

        #endregion

        #region MaxLength

        public const int SS_NAME_MAX_LENGTH = (int)MaxLength.MAX_256;

        #endregion
    }
}