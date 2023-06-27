

namespace StoreBasicCRUD.ApplicationCoreStructure.ApplicationEntities.Consts
{
    public class ProductColumnsName
    {
        public const string IDPRODUCT_COLUMN = "IdProduct";
        public const string NAME_COLUMN = "Name";
        public const string CATEGORY_COLUMN = "Category";

        public static List<string> ElementsList()
        {
            List<string> elementsList = new () { IDPRODUCT_COLUMN.ToLower(), 
                                                    NAME_COLUMN.ToLower(), 
                                                    CATEGORY_COLUMN.ToLower() 
                                                };
            return elementsList;
        }
    }
}
