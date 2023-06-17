using StoreBasicCRUD.Persistence_SQLServer.Interfaces.IProductsRepository.Commands;
using StoreBasicCRUD.Persistence_SQLServer.Interfaces.IProductsRepository.Queries;

namespace StoreBasicCRUD.Persistence_SQLServer.Interfaces.IUnitsOfWork
{
    public interface IProductsUnitOfWork<T> where T : class
    {
        IGetAllProductsRepository GetProductsRepository { get; }
        IGetProductByIdRepository GetProductRepository { get; }
        IExistProductRepository ExistProductRepository { get; }
        IRemoveProductRepository RemoveProductRepository { get; }
        ISaveProductRepository SaveProductRepository { get; }
        IUpdateProductRepository UpdateProductRepository { get;}
    }
}
