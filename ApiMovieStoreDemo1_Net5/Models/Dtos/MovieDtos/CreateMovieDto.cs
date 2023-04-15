using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using static ApiMovieStoreDemo1_Net5.Models.Movie;

namespace ApiMovieStoreDemo1_Net5.Models.Dtos.MovieDtos
{
    public class CreateMovieDto
    {
        [Required]
        public string Nombre { get; set; }
        public IFormFile Photo { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string MovieLength { get; set; }
        [Required]
        public ClasificationType Clasification { get; set; }
        [Required]
        public string CreatedBy { get; set; }
        [Required]
        public int CategoryId { get; set; }
    }
}
