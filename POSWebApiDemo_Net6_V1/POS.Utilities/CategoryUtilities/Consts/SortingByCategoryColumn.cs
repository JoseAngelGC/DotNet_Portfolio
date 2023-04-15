

namespace POS.Utilities.CategoryUtilities.Consts
{
    public class SortingByCategoryColumn
    {
        public const string ID_COLUMN = "Id";
        public const string Name_COLUMN = "Name";

        public static List<string> ElementsList()
        {
            List<string> elementsList = new List<string> { ID_COLUMN.ToLower(), Name_COLUMN.ToLower() };
            return elementsList;
        }
        
    }
}
