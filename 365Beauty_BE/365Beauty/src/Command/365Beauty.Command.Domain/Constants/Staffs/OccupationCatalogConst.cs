using _365Beauty.Contract.Enumerations;

namespace _365Beauty.Command.Domain.Constants.Staffs
{
    public class OccupationCatalogConst
    {
        #region Fields

        public const string TABLE_NAME = "occupation_catalog";
        public const string FIELD_OCCUPATION_ID = "occupation_id";
        public const string FIELD_OCC_NAME = "occ_name";

        #endregion

        #region MaxLength

        public const int OCCUPATION_NAME_MAX_LENGTH = (int)MaxLength.MAX_64;

        #endregion
    }
}