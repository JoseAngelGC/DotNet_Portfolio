using Microsoft.EntityFrameworkCore;
using POS.DomainSqlServer.EFCore.DatabaseFirst.Entities;
using POS.Persistence.Contexts.DomainSQLServer.EFCore.DataBaseFirst.Context;
using POS.Persistence.Interfaces.UserRepository.Queries.ExistItem;


namespace POS.Persistence.Repository.UserRepository.Queries.ExistItem
{
    public class ExistUserItemByNameRepository<T> : IExistUserItemByNameRepository where T : User
    {
        private readonly POSContext _context;
        private readonly DbSet<T> _entity;
        public ExistUserItemByNameRepository(POSContext context)
        {
            _context = context;
            _entity = _context.Set<T>();
        }
        public async Task<bool> ExistItemAsync(string name)
        {
            var existItem = await _entity.AnyAsync(c => c.UserName!.ToLower().Trim() == name.ToLower().Trim());
            return existItem;
        }
    }
}
