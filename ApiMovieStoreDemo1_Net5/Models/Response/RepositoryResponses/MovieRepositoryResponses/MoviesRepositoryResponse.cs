using ApiMovieStoreDemo1_Net5.Models.Response.BaseResponses;
using System.Collections.Generic;

namespace ApiMovieStoreDemo1_Net5.Models.Response.RepositoryResponses.MovieRepositoryResponses
{
    public class MoviesRepositoryResponse:BaseRepositoryResponses
    {
        public ICollection<Movie> MovieCollectionRepositoryResponse { get; set; }
    }
}
