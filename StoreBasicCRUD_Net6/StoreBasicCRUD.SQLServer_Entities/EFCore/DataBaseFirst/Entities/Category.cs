

namespace StoreBasicCRUD.SQLServer_Entities.EFCore.DataBaseFirst.Entities
{
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        public int IdCategory { get; set; }
        public string Nombre { get; set; } = null!;

        public virtual ICollection<Product> Products { get; set; }
    }
}
