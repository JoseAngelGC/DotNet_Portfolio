

namespace StoreBasicCRUD.ApplicationCoreStructure.ApplicationDtos.Products.PivotsDtos
{
    public class ProductPivotDto
    {
        public int IdProduct { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int IdCategory { get; set; }
    }
}
