using POS.DomainSqlServer.EFCore.DatabaseFirst.Entities.BaseEntities;
using POS.Persistence.Contexts.DomainSQLServer.EFCore.DataBaseFirst.Context;
using POS.Persistence.Interfaces.Generics.Queries.GetItem;
using POS.Persistence.Interfaces.Generics.Queries.GetList;
using POS.Persistence.Interfaces.UnitsOfWork.Generics;
using POS.Persistence.Repository.GenericRepositories.Queries.GetItem;
using POS.Persistence.Repository.GenericRepositories.Queries.GetList;

namespace POS.Persistence.Repository.UnitsOfWork.Generics
{
    public class GenericRepositoryQueriesUnitOfWork<T> : IGenericRepositoryQueriesUnitOfWork<T> where T : BaseEntity
    {
        private readonly POSContext _context;
        public IGenericGetListToFilter<T> GenericGetListToFiter { get; private set; }
        public IGenericGetAllList<T> GenericGetAllList { get; private set; }
        public IGenericGetEntityItemById<T> GenericGetEntityItemById { get; private set; }

        public GenericRepositoryQueriesUnitOfWork(POSContext context)
        {
            _context = context;
            GenericGetListToFiter = new GenericGetListToFilter<T>(_context);
            GenericGetAllList = new GenericGetAllList<T>(_context);
            GenericGetEntityItemById = new GenericGetEntityItemById<T>(_context);
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
