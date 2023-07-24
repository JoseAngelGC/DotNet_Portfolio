using System.ComponentModel.DataAnnotations;

namespace ApiCrudWithBlazor.BlazorClient.DomainModels.CoreEntities.Dtos
{
    public class ProductDto
    {
        public int IdProduct { get; set; }
        [Required(ErrorMessage = "El campo {()} es requerido.")]
        public string Nombre { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "El campo {()} es requerido.")]
        public decimal Precio { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "El campo {()} es requerido.")]
        public int IdCategory { get; set; }
        public string Category { get; set; }
        public CategoryDto CategoryDto { get; set; }
    }
}
