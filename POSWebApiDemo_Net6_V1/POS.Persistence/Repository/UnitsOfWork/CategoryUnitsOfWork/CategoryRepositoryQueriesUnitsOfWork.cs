using POS.DomainSqlServer.EFCore.DatabaseFirst.Entities;
using POS.Persistence.Contexts.DomainSQLServer.EFCore.DataBaseFirst.Context;
using POS.Persistence.Interfaces.Generics.Queries.GetItem;
using POS.Persistence.Interfaces.Generics.Queries.GetList;
using POS.Persistence.Interfaces.UnitsOfWork.CategoryUnitsOfWork;
using POS.Persistence.Repository.GenericRepositories.Queries.GetItem;
using POS.Persistence.Repository.GenericRepositories.Queries.GetList;


namespace POS.Persistence.Repository.UnitsOfWork.CategoryUnitsOfWork
{
    public class CategoryRepositoryQueriesUnitsOfWork<T> : ICategoryRepositoryQueriesUnitsOfWork<T> where T : Category
    {
        private readonly POSContext _context;
        public IGenericGetListToFilter<T> GenericGetListToFiter { get; private set; }
        public IGenericGetAllList<T> GenericGetAllList { get; private set; }
        public IGenericGetEntityItemById<T> GenericGetEntityItemById { get; private set; }
        public CategoryRepositoryQueriesUnitsOfWork(POSContext context)
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
