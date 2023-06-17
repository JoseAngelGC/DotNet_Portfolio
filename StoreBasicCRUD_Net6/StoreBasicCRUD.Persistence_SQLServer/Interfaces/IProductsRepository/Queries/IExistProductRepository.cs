namespace StoreBasicCRUD.Persistence_SQLServer.Interfaces.IProductsRepository.Queries
{
    public interface IExistProductRepository
    {
        Task<bool> ResponseAsync(string productName, int categoryId, int? productId = null);
        Task<bool> ResponseAsync(int productId);
    }
}
