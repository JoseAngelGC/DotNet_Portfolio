using StoreBasicCRUD.ApplicationCoreStructure.ApplicationDtos.Products.EntitiesDtos;

namespace StoreBasicCRUD.Persistence_SQLServer.Interfaces.IProductsRepository.Queries
{
    public interface IGetAllProductsRepository
    {
        Task<IQueryable<ProductDto>> ResponsesAsync();
    }
}
