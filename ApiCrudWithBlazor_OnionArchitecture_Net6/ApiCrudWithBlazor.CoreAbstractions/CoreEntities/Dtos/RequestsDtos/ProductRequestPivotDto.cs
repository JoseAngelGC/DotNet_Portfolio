

namespace ApiCrudWithBlazor.CoreAbstractions.CoreEntities.Dtos.RequestsDtos
{
    public class ProductRequestPivotDto
    {
        public int IdProduct { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int IdCategory { get; set; }
    }
}
