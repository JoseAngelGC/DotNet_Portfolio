using StoreBasicCRUD.Persistence_SQLServer.Context;
using StoreBasicCRUD.Persistence_SQLServer.Interfaces.ICategariesRepository.Queries;
using StoreBasicCRUD.Persistence_SQLServer.Interfaces.IUnitsOfWork;
using StoreBasicCRUD.Persistence_SQLServer.Repositories.CategoriesRepository.Queries;

namespace StoreBasicCRUD.Persistence_SQLServer.UnitsOfWork
{
    public class CategoriesUnitOfWork<T> : ICategoriesUnitOfWork<T> where T : class
    {
        private readonly StoreBasicCrudContext _context;
        public IGetAllCategoriesRepository GetCategoriesRepository { get; private set; }
        public IGetCategoryByCategoryNameRepository GetCategoryByNameRepository { get; private set; }

        public CategoriesUnitOfWork(StoreBasicCrudContext context)
        {
            _context = context;
            GetCategoriesRepository = new GetAllCategoriesRepository(context);
            GetCategoryByNameRepository = new GetCategoryByCategoryNameRepository(context);
        }
    }
}
