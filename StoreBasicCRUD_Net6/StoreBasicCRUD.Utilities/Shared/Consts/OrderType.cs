

namespace StoreBasicCRUD.Utilities.Shared.Consts
{
    public class OrderType
    {
        public const string ASCEND_ORDERING = "asc";
        public const string DESCEND_ORDERING = "desc";
        public static List<string> ElementsList()
        {
            List<string> elementsList = new () { ASCEND_ORDERING, DESCEND_ORDERING };
            return elementsList;
        }
    }
}
