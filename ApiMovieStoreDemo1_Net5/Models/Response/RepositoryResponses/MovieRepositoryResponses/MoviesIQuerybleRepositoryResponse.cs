using ApiMovieStoreDemo1_Net5.Models.Response.BaseResponses;
using System.Linq;

namespace ApiMovieStoreDemo1_Net5.Models.Response.RepositoryResponses.MovieRepositoryResponses
{
    public class MoviesIQuerybleRepositoryResponse:BaseRepositoryResponses
    {
        public IQueryable<Movie> MoviesIQuerybleRepoResponse { get; set; }
    }
}
