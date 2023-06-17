using StoreBasicCRUD.Persistence_SQLServer.Context;
using StoreBasicCRUD.Persistence_SQLServer.Interfaces.IProductsRepository.Commands;
using StoreBasicCRUD.Persistence_SQLServer.Interfaces.IProductsRepository.Queries;
using StoreBasicCRUD.Persistence_SQLServer.Interfaces.IUnitsOfWork;
using StoreBasicCRUD.Persistence_SQLServer.Repositories.ProductsRepository.Commands;
using StoreBasicCRUD.Persistence_SQLServer.Repositories.ProductsRepository.Queries;

namespace StoreBasicCRUD.Persistence_SQLServer.UnitsOfWork
{
    public class ProductsUnitOfWork<T> : IProductsUnitOfWork<T> where T : class
    {
        private readonly StoreBasicCrudContext _context;
        public IGetAllProductsRepository GetProductsRepository { get; private set; }
        public IGetProductByIdRepository GetProductRepository { get; private set; }
        public IExistProductRepository ExistProductRepository { get; private set; }
        public IRemoveProductRepository RemoveProductRepository { get; private set; }
        public ISaveProductRepository SaveProductRepository { get; private set; }
        public IUpdateProductRepository UpdateProductRepository { get; private set; }

        public ProductsUnitOfWork(StoreBasicCrudContext context)
        {
            _context = context;
            GetProductsRepository = new GetAllProductsRepository(_context);
            ExistProductRepository = new ExistProductRepository(_context);
            RemoveProductRepository = new RemoveProductRepository(_context);
            SaveProductRepository = new SaveProductRepository(_context);
            UpdateProductRepository = new UpdateProductRepository(_context);
            GetProductRepository = new GetProductByIdRepository(_context);
        }
    }
}
