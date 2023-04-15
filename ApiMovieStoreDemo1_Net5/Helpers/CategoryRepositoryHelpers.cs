using ApiMovieStoreDemo1_Net5.Helpers.IHelpers;
using ApiMovieStoreDemo1_Net5.Models;
using ApiMovieStoreDemo1_Net5.Models.Response.RepositoryResponses.CategoryRepositoryResponses;
using System.Collections.Generic;

namespace ApiMovieStoreDemo1_Net5.Helpers
{
    public class CategoryRepositoryHelpers : ICategoryRepositoryHelpers
    {
        public CategoryRepositoryResponse CategoryRepositoryResponseHelper(int code, string message)
        {
            CategoryRepositoryResponse response = new();
            response.OperationCodeRepositoryResponse = code;
            response.MessageRepositoryResponse = message;
            return response;
        }

        public CategoryRepositoryResponse CategoryRepositoryResponseHelper(int code, Category categoryData)
        {
            CategoryRepositoryResponse response = new();
            response.OperationCodeRepositoryResponse = code;
            response.CategoryDataRepositoryResponse = categoryData;
            return response;
        }

        public CategoriesRepositoryResponse CategoriesRepositoryResponseHelper(int code, string message)
        {
            CategoriesRepositoryResponse response = new();
            response.OperationCodeRepositoryResponse = code;
            response.MessageRepositoryResponse = message;
            return response;
        }

        public CategoriesRepositoryResponse CategoriesRepositoryResponseHelper(int code, ICollection<Category> categoryCollection)
        {
            CategoriesRepositoryResponse response = new();
            response.OperationCodeRepositoryResponse = code;
            response.CategoryCollectionRepositoryResponse = categoryCollection;
            return response;
        }

        public ExistCategoryRepositoryResponse ExistCategoryRepositoryResponseHelper(int code, bool existCategory, string message)
        {
            ExistCategoryRepositoryResponse response = new();
            response.OperationCodeRepositoryResponse = code;
            response.ExistCategoryRepoResponse = existCategory;
            response.MessageRepositoryResponse = message;
            return response;
        }
    }
}
