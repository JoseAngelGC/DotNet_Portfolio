namespace ApiCrudWithBlazor.CoreAbstractions.CoreEntities.Utilities.Constants
{
    public class SortingConstants
    {
        public const string ASCEND_ORDERING = "asc";
        public const string DESCEND_ORDERING = "desc";
        public static List<string> ElementsList()
        {
            List<string> elementsList = new() { ASCEND_ORDERING, DESCEND_ORDERING };
            return elementsList;
        }
    }
}
