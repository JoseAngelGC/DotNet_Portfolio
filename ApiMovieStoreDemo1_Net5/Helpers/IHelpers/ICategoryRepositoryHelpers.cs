using ApiMovieStoreDemo1_Net5.Models;
using ApiMovieStoreDemo1_Net5.Models.Response.RepositoryResponses.CategoryRepositoryResponses;
using System.Collections.Generic;

namespace ApiMovieStoreDemo1_Net5.Helpers.IHelpers
{
    public interface ICategoryRepositoryHelpers
    {
        CategoryRepositoryResponse CategoryRepositoryResponseHelper(int code, string message);
        CategoryRepositoryResponse CategoryRepositoryResponseHelper(int code, Category categoryData);
        CategoriesRepositoryResponse CategoriesRepositoryResponseHelper(int code, string message);
        CategoriesRepositoryResponse CategoriesRepositoryResponseHelper(int code, ICollection<Category> categoryCollection);
        ExistCategoryRepositoryResponse ExistCategoryRepositoryResponseHelper(int code, bool existCategory, string message);
    }
}
