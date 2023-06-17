using StoreBasicCRUD.SQLServer_Entities.EFCore.DataBaseFirst.Entities;


namespace StoreBasicCRUD.Persistence_SQLServer.Interfaces.IProductsRepository.Commands
{
    public interface IRemoveProductRepository
    {
        Task<int> ResponseAsync(Product productModel);
    }
}
