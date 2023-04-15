using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using static ApiMovieStoreDemo1_Net5.Models.Movie;

namespace ApiMovieStoreDemo1_Net5.Models.Dtos.MovieDtos
{
    public class UpdateMovieDto
    {
        [Required]
        public int MovieId { get; set; }
        [Required]
        public string MovieName { get; set; }
        public IFormFile Photo { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string MovieLength { get; set; }
        [Required]
        public ClasificationType Clasification { get; set; }
        [Required]
        public string UpdatedBy { get; set; }
        [Required]
        public int CategoryId { get; set; }
    }
}
