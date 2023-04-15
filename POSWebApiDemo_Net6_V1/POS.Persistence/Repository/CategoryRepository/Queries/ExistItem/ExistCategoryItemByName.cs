using Microsoft.EntityFrameworkCore;
using POS.DomainSqlServer.EFCore.DatabaseFirst.Entities;
using POS.Persistence.Contexts.DomainSQLServer.EFCore.DataBaseFirst.Context;
using POS.Persistence.Interfaces.CategoryRepository.Queries.ExistItem;


namespace POS.Persistence.Repository.CategoryRepository.Queries.ExistItem
{
    public class ExistCategoryItemByName<T>: IExistCategoryItemByName where T : Category
    {
        private readonly POSContext _context;
        private readonly DbSet<T> _entity;
        public ExistCategoryItemByName(POSContext context)
        {
            _context = context;
            _entity = _context.Set<T>();
        }
        public async Task<bool> GetItemAsync(string name)
        {
            var existItem = await _entity.AnyAsync(c => c.Name!.ToLower().Trim() == name.ToLower().Trim());
            return existItem;
        }
    }
}
