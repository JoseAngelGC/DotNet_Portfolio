using Microsoft.EntityFrameworkCore;
using POS.DomainSqlServer.EFCore.DatabaseFirst.Entities;
using POS.Persistence.Contexts.DomainSQLServer.EFCore.DataBaseFirst.Context;
using POS.Persistence.Interfaces.UserRepository.Queries.GetItem;

namespace POS.Persistence.Repository.UserRepository.Queries.GetItem
{
    public class AccountByUserNameRepository<T> : IAccountByUserNameRepository<T> where T : User
    {
        private readonly POSContext _context;
        private readonly DbSet<T> _entity;

        public AccountByUserNameRepository(POSContext context)
        {
            _context = context;
            _entity = _context.Set<T>();
        }
        public async Task<T> GetUserAccountAsync(string name)
        {
            var userAccountItem = await _entity.AsNoTracking().FirstOrDefaultAsync(c => c.UserName!.ToLower().Trim() == name.ToLower().Trim());
            return userAccountItem!;
        }
    }
}
