using Microsoft.EntityFrameworkCore;
using StoreBasicCRUD.Persistence_SQLServer.Context;
using StoreBasicCRUD.Persistence_SQLServer.Interfaces.ICategariesRepository.Queries;
using StoreBasicCRUD.SQLServer_Entities.EFCore.DataBaseFirst.Entities;

namespace StoreBasicCRUD.Persistence_SQLServer.Repositories.CategoriesRepository.Queries
{
    public class GetCategoryByCategoryNameRepository : IGetCategoryByCategoryNameRepository
    {
        private readonly StoreBasicCrudContext _context;
        public GetCategoryByCategoryNameRepository(StoreBasicCrudContext context)
        {
            _context = context;
        }
        public async Task<Category> ResponseAsync(string categoryName)
        {
            var categoryresponse = await _context.Categories.FirstOrDefaultAsync(c => c.Nombre.ToLower().Trim() == categoryName.ToLower().Trim());
            return categoryresponse!;
        }
    }
}
