using ApiMovieStoreDemo1_Net5.Models.Dtos.CategoryDtos;
using ApiMovieStoreDemo1_Net5.Models.Response.ServiceResponses.Common;
using System.Threading.Tasks;

namespace ApiMovieStoreDemo1_Net5.Services.IServices
{
    public interface ICategoryService
    {
        Task<CommonServiceResponse> GetCategoriesService();
        Task<CommonServiceResponse> GetCategoryService(int categoryId);
        Task<CommonServiceResponse> CreateCategoryService(CreateCategoryDto createCategoryDto);
        Task<CommonServiceResponse> UpdateCategoryService(UpdateCategoryDto updateCategoryDto);
        Task<CommonServiceResponse> DeleteCategoryService(int id);
    }
}
