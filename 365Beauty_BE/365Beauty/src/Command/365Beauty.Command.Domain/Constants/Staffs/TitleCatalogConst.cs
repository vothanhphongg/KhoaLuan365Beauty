using _365Beauty.Contract.Enumerations;

namespace _365Beauty.Command.Domain.Constants.Staffs
{
    public class TitleCatalogConst
    {
        #region Fields

        public const string TABLE_NAME = "title_catalog";
        public const string FIELD_TITLE_ID = "title_id";
        public const string FIELD_TITLE_NAME = "title_name";

        #endregion

        #region Maxlength

        public const int TITLE_NAME_MAX_LENGTH = (int)MaxLength.MAX_64;

        #endregion
    }
}