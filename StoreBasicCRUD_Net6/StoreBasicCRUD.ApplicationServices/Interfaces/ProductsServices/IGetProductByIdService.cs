using StoreBasicCRUD.ApplicationCoreStructure.ApplicationDtos.Products.EntitiesDtos;
using StoreBasicCRUD.ApplicationCoreStructure.ApplicationEntities.Responses.Queries;


namespace StoreBasicCRUD.ApplicationServices.Interfaces.ProductsServices
{
    public interface IGetProductByIdService
    {
        Task<ApplicationServiceQueryResponseEntity<ProductDto>> ResponseAsync(int productId);
    }
}
