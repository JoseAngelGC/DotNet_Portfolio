using StoreBasicCRUD.SQLServer_Entities.EFCore.DataBaseFirst.Entities;

namespace StoreBasicCRUD.Persistence_SQLServer.Interfaces.IProductsRepository.Queries
{
    public interface IGetProductByIdRepository
    {
        Task<Product> ResponsesAsync(int productId);
    }
}
