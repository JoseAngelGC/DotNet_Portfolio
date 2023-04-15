using ApiMovieStoreDemo1_Net5.Data;
using ApiMovieStoreDemo1_Net5.Helpers.IHelpers;
using ApiMovieStoreDemo1_Net5.Models;
using ApiMovieStoreDemo1_Net5.Models.Response.RepositoryResponses.CategoryRepositoryResponses;
using ApiMovieStoreDemo1_Net5.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMovieStoreDemo1_Net5.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _db;
        private readonly ICategoryRepositoryHelpers _icrh;
        public CategoryRepository(AppDbContext db, ICategoryRepositoryHelpers icategoryRepositoryHelpers)
        {
            _db = db;
            _icrh = icategoryRepositoryHelpers;
        }

        public async Task<CategoryRepositoryResponse> CreateCategory(Category categoryModel)
        {
            using (var transaction = _db.Database.BeginTransaction())
            {
                try
                {
                    _db.Categories.Add(categoryModel);
                    await _db.SaveChangesAsync();
                    transaction.Commit();
                    return _icrh.CategoryRepositoryResponseHelper(1, "success");
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return _icrh.CategoryRepositoryResponseHelper(-1, ex.Message);
                }
            }
        }

        public async Task<ExistCategoryRepositoryResponse> ExistCategory(int categoryId)
        {
            try
            {
                var existCategory = await _db.Categories.AnyAsync(c => c.CategoryId == categoryId);
                return _icrh.ExistCategoryRepositoryResponseHelper(1, existCategory, "success");
            }
            catch (Exception ex)
            {
                return _icrh.ExistCategoryRepositoryResponseHelper(-1, false, ex.Message);
            }
        }

        public async Task<ExistCategoryRepositoryResponse> ExistCategoryByName(string categoryName)
        {
            try
            {
                var existCategory = await _db.Categories.AnyAsync(c => c.CategoryName.ToLower().Trim() == categoryName.ToLower().Trim());
                return _icrh.ExistCategoryRepositoryResponseHelper(1, existCategory, "success");
            }
            catch (Exception ex)
            {
                return _icrh.ExistCategoryRepositoryResponseHelper(-1, false, ex.Message);
            }
        }

        public async Task<CategoriesRepositoryResponse> GetCategories()
        {
            try
            {
                List<Category> collectionCategory = await _db.Categories.OrderBy(c => c.CategoryName).ToListAsync();
                return _icrh.CategoriesRepositoryResponseHelper(1, collectionCategory);
            }
            catch (Exception ex)
            {
                return _icrh.CategoriesRepositoryResponseHelper(-1, ex.Message);
            }
        }

        public async Task<CategoryRepositoryResponse> GetCategory(int categoryId)
        {
            try
            {
                var categoryData = await _db.Categories.FirstOrDefaultAsync(c => c.CategoryId == categoryId);
                return _icrh.CategoryRepositoryResponseHelper(1, categoryData);
            }
            catch (Exception ex)
            {
                return _icrh.CategoryRepositoryResponseHelper(-1, ex.Message);
            }
        }

        public async Task<CategoryRepositoryResponse> UpdateCategory(Category categoryModel)
        {
            using (var transaction = _db.Database.BeginTransaction())
            {
                try
                {
                    _db.Categories.Update(categoryModel);
                    await _db.SaveChangesAsync();
                    transaction.Commit();
                    return _icrh.CategoryRepositoryResponseHelper(1, "success");

                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return _icrh.CategoryRepositoryResponseHelper(-1, ex.Message);
                }
            }
        }

        public async Task<CategoryRepositoryResponse> DeleteCategory(Category categoryModel)
        {
            using (var transaction = _db.Database.BeginTransaction())
            {
                try
                {
                    _db.Categories.Remove(categoryModel);
                    await _db.SaveChangesAsync();
                    transaction.Commit();
                    return _icrh.CategoryRepositoryResponseHelper(1, "success");
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return _icrh.CategoryRepositoryResponseHelper(-1, ex.Message);
                }
            }
        }
    }
}
