using System.Data.Common;

namespace POS.Utilities.Commons.Consts
{
    public class OrderingType
    {
        public const string ASCEND_ORDERING = "asc";
        public const string DESCEND_ORDERING = "desc";
        public static List<string> ElementsList()
        {
            List<string> elementsList = new List<string> { ASCEND_ORDERING, DESCEND_ORDERING };
            return elementsList;
        }
    }
}
