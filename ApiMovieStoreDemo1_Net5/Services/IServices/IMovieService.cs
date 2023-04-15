using ApiMovieStoreDemo1_Net5.Models.Dtos.MovieDtos;
using ApiMovieStoreDemo1_Net5.Models.Response.ServiceResponses.Common;
using System.Threading.Tasks;

namespace ApiMovieStoreDemo1_Net5.Services.IServices
{
    public interface IMovieService
    {
        Task<CommonServiceResponse> GetMoviesService();
        Task<CommonServiceResponse> GetMovieService(int movieId);
        Task<CommonServiceResponse> GetMoviesByCategoryService(int categoryId);
        Task<CommonServiceResponse> CreateMovieService(CreateMovieDto createMovieDto);
        Task<CommonServiceResponse> SearchMovieService(string movieName);
        Task<CommonServiceResponse> UpdateMovieService(UpdateMovieDto updateMovieDto);
        Task<CommonServiceResponse> DeleteMovieService(int movieId);
    }
}
