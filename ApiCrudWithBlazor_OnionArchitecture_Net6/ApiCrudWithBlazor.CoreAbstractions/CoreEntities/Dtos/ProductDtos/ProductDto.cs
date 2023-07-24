using ApiCrudWithBlazor.Entities.ApiCrud.EFCore.Bases;

namespace ApiCrudWithBlazor.CoreAbstractions.CoreEntities.Dtos.ProductDtos
{
    public class ProductDto : BaseEntity
    {
        public int IdProduct { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int IdCategory { get; set; }
        public string Category { get; set; }
    }
}
