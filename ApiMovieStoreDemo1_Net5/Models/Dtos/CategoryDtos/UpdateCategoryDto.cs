using System.ComponentModel.DataAnnotations;

namespace ApiMovieStoreDemo1_Net5.Models.Dtos.CategoryDtos
{
    public class UpdateCategoryDto
    {
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string UpdatedBy { get; set; }
    }
}
