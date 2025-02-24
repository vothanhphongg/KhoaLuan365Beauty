using _365Beauty.Contract.Enumerations;

namespace _365Beauty.Command.Domain.Constants.Staffs
{
    public class DegreeCatalogConst
    {
        #region Fields

        public const string TABLE_NAME = "degree_catalog";
        public const string FIELD_DEGREE_ID = "degree_id";
        public const string FIELD_DEG_NAME = "deg_name";

        #endregion

        #region MaxLength

        public const int DEGREE_NAME_MAX_LENGTH = (int)MaxLength.MAX_64;

        #endregion
    }
}