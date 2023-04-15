using POS.DomainSqlServer.EFCore.DatabaseFirst.Entities.BaseEntities;
using POS.Persistence.Contexts.DomainSQLServer.EFCore.DataBaseFirst.Context;
using POS.Persistence.Interfaces.Generics.Commands.RemoveItem;
using POS.Persistence.Interfaces.Generics.Commands.SaveItem;
using POS.Persistence.Interfaces.Generics.Commands.UpdateItem;
using POS.Persistence.Interfaces.UnitsOfWork.Generics;
using POS.Persistence.Repository.GenericRepositories.Commands.RemoveItem;
using POS.Persistence.Repository.GenericRepositories.Commands.SaveItem;
using POS.Persistence.Repository.GenericRepositories.Commands.UpdateItem;


namespace POS.Persistence.Repository.UnitsOfWork.Generics
{
    public class GenericRepositoryCommandsUnitOfWork<T> : IGenericRepositoryCommandsUnitOfWork<T> where T : BaseEntity
    {
        private readonly POSContext _context;
        public IGenericSaveEntityItem<T> GenericSaveEntityItem { get; private set; }
        public IGenericUpdateEntityItem<T> GenericUpdateEntityItem { get; private set; }
        public IGenericRemoveEntityItem<T> GenericRemoveEntityItem { get; private set; }
        public GenericRepositoryCommandsUnitOfWork(POSContext context)
        {
            _context = context;
            GenericSaveEntityItem = new GenericSaveEntityItemCommand<T>(_context);
            GenericUpdateEntityItem = new GenericUpdateEntityItemCommand<T>(_context);
            GenericRemoveEntityItem = new GenericRemoveEntityItemCommand<T>(_context);
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
