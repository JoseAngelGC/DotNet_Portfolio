using ApiMovieStoreDemo1_Net5.Models;
using ApiMovieStoreDemo1_Net5.Models.Response.RepositoryResponses.CategoryRepositoryResponses;
using System.Threading.Tasks;

namespace ApiMovieStoreDemo1_Net5.Repository.IRepository
{
    public interface ICategoryRepository
    {
        Task<CategoriesRepositoryResponse> GetCategories();
        Task<CategoryRepositoryResponse> GetCategory(int categoryId);
        Task<ExistCategoryRepositoryResponse> ExistCategoryByName(string categoryName);
        Task<ExistCategoryRepositoryResponse> ExistCategory(int categoryId);
        Task<CategoryRepositoryResponse> CreateCategory(Category categoryModel);
        Task<CategoryRepositoryResponse> UpdateCategory(Category categoryModel);
        Task<CategoryRepositoryResponse> DeleteCategory(Category categoryModel);
    }
}
