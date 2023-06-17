using StoreBasicCRUD.SQLServer_Entities.EFCore.DataBaseFirst.Entities;


namespace StoreBasicCRUD.Persistence_SQLServer.Interfaces.IProductsRepository.Commands
{
    public interface IUpdateProductRepository
    {
        Task<int> ResponseAsync(Product productModel);
    }
}
