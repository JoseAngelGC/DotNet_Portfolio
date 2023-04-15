using System.ComponentModel.DataAnnotations;

namespace ApiMovieStoreDemo1_Net5.Models.Dtos.CategoryDtos
{
    public class DeleteCategoryDto
    {
        [Required]
        public int id { get; set; }
    }
}
