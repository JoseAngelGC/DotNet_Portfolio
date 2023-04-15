using Microsoft.EntityFrameworkCore;
using POS.DomainSqlServer.EFCore.DatabaseFirst.Entities;
using POS.Persistence.Contexts.DomainSQLServer.EFCore.DataBaseFirst.Context;
using POS.Persistence.Interfaces.CategoryRepository.Queries.ExistItem;


namespace POS.Persistence.Repository.CategoryRepository.Queries.ExistItem
{
    public class ExistCategoryItemById<T> : IExistCategoryItemById where T : Category
    {
        private readonly POSContext _context;
        private readonly DbSet<T> _entity;
        public ExistCategoryItemById(POSContext context)
        {
            _context = context;
            _entity = _context.Set<T>();
        }

        public async Task<bool> ResponseAsync(int id)
        {
            var existItem = await _entity.AnyAsync(c => c.Id == id);
            return existItem;
        }
    }
}
