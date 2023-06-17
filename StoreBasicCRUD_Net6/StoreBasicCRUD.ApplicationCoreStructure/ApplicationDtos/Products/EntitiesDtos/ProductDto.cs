

namespace StoreBasicCRUD.ApplicationCoreStructure.ApplicationDtos.Products.EntitiesDtos
{
    public class ProductDto
    {
        public int IdProduct { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int IdCategory { get; set; }
        public string Category { get; set; }
    }
}
