

namespace StoreBasicCRUD.SQLServer_Entities.EFCore.DataBaseFirst.Entities
{
    public partial class Product
    {
        public int IdProduct { get; set; }
        public string Nombre { get; set; } = null!;
        public decimal Precio { get; set; }
        public int IdCategory { get; set; }

        public virtual Category IdCategoryNavigation { get; set; } = null!;
    }
}
