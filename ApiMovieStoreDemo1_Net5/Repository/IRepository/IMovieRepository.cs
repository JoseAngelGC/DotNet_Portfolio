using ApiMovieStoreDemo1_Net5.Models;
using ApiMovieStoreDemo1_Net5.Models.Response.RepositoryResponses.MovieRepositoryResponses;
using System.Threading.Tasks;

namespace ApiMovieStoreDemo1_Net5.Repository.IRepository
{
    public interface IMovieRepository
    {
        Task<MoviesRepositoryResponse> GetMovies();
        Task<MovieRepositoryResponse> GetMovie(int movieId);
        Task<MoviesRepositoryResponse> GetMoviesByCategory(int categoryId);
        Task<ExistMovieRepositoryResponse> ExistMovieByName(string movieName);
        Task<ExistMovieRepositoryResponse> ExistMovie(int movieId);
        Task<MovieRepositoryResponse> CreateMovie(Movie movieModel);
        Task<MoviesIQuerybleRepositoryResponse> SearchMovie(string movieName);
        Task<MovieRepositoryResponse> UpdateMovie(Movie movieModel);
        Task<MovieRepositoryResponse> DeleteMovie(Movie movieModel);
    }
}
