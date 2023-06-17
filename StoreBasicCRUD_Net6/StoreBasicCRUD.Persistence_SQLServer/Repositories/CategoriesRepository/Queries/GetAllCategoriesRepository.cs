using Microsoft.EntityFrameworkCore;
using StoreBasicCRUD.Persistence_SQLServer.Context;
using StoreBasicCRUD.Persistence_SQLServer.Interfaces.ICategariesRepository.Queries;
using StoreBasicCRUD.SQLServer_Entities.EFCore.DataBaseFirst.Entities;

namespace StoreBasicCRUD.Persistence_SQLServer.Repositories.CategoriesRepository.Queries
{
    public class GetAllCategoriesRepository : IGetAllCategoriesRepository
    {
        private readonly StoreBasicCrudContext _context;
        public GetAllCategoriesRepository(StoreBasicCrudContext context)
        {
            _context = context;
        }
        public async Task<List<Category>> ResponsesAsync()
        {
            List<Category> registerListResponse = await _context.Categories.OrderBy(c => c.IdCategory).ToListAsync();
            return registerListResponse;
        }
    }
}
