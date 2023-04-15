using System;
using static ApiMovieStoreDemo1_Net5.Models.Movie;

namespace ApiMovieStoreDemo1_Net5.Models.Dtos.MovieDtos
{
    public class MovieDto
    {
        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public string Description { get; set; }
        public string MovieLength { get; set; }
        public ClasificationType Clasification { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int CategoryId { get; set; }
    }
}
