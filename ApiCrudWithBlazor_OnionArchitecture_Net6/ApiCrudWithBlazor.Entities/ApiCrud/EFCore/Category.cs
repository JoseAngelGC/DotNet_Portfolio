using ApiCrudWithBlazor.Entities.ApiCrud.EFCore.Bases;

namespace ApiCrudWithBlazor.Entities.ApiCrud.EFCore
{
    public partial class Category : BaseEntity
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
