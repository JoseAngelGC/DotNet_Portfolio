using ApiCrudWithBlazor.Entities.ApiCrud.EFCore.Bases;


namespace ApiCrudWithBlazor.Entities.ApiCrud.EFCore
{
    public partial class Product : BaseEntity
    {
        public int IdProduct { get; set; }
        public string Nombre { get; set; } = null!;
        public decimal Precio { get; set; }
        public int IdCategory { get; set; }

        public virtual Category IdCategoryNavigation { get; set; } = null!;
    }
}
