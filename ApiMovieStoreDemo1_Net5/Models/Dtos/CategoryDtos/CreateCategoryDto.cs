using System.ComponentModel.DataAnnotations;

namespace ApiMovieStoreDemo1_Net5.Models.Dtos.CategoryDtos
{
    public class CreateCategoryDto
    {
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string CreatedBy { get; set; }
    }
}
