using POS.DomainSqlServer.EFCore.DatabaseFirst.Entities;
using POS.Persistence.Contexts.DomainSQLServer.EFCore.DataBaseFirst.Context;
using POS.Persistence.Interfaces.Generics.Commands.SaveItem;
using POS.Persistence.Interfaces.UnitsOfWork.UserUnitsOfWork;
using POS.Persistence.Interfaces.UserRepository.Queries.ExistItem;
using POS.Persistence.Repository.GenericRepositories.Commands.SaveItem;
using POS.Persistence.Repository.UserRepository.Queries.ExistItem;

namespace POS.Persistence.Repository.UnitsOfWork.UserUnitsOfWork
{
    public class UserCommandsUnitOfWork<T> : IUserCommandsUnitOfWork<T> where T : User
    {
        private readonly POSContext _context;
        public IGenericSaveEntityItem<T> GenericSaveEntityItem { get; private set; }
        public IExistUserItemByNameRepository ExistUserItemByName { get; private set; }
        public UserCommandsUnitOfWork(POSContext context)
        {
            _context = context;
            GenericSaveEntityItem = new GenericSaveEntityItemCommand<T>(_context);
            ExistUserItemByName = new ExistUserItemByNameRepository<T>(_context);
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
