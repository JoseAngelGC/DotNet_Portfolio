using POS.DomainSqlServer.EFCore.DatabaseFirst.Entities;
using POS.Persistence.Contexts.DomainSQLServer.EFCore.DataBaseFirst.Context;
using POS.Persistence.Interfaces.UnitsOfWork.UserUnitsOfWork;
using POS.Persistence.Interfaces.UserRepository.Queries.GetItem;
using POS.Persistence.Repository.UserRepository.Queries.GetItem;


namespace POS.Persistence.Repository.UnitsOfWork.UserUnitsOfWork
{
    public class UserQueriesUnitOfWork<T> : IUserQueriesUnitOfWork<T> where T : User
    {
        private readonly POSContext _context;
        public IAccountByUserNameRepository<T> AccountByUserName { get; private set; }

        public UserQueriesUnitOfWork(POSContext context)
        {
            _context = context;
            AccountByUserName = new AccountByUserNameRepository<T>(_context);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
