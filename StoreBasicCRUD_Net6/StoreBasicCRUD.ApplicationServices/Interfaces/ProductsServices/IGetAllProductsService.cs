using StoreBasicCRUD.ApplicationCoreStructure.ApplicationDtos.Products.EntitiesDtos;
using StoreBasicCRUD.ApplicationCoreStructure.ApplicationEntities.Responses.Queries;


namespace StoreBasicCRUD.ApplicationServices.Interfaces.ProductsServices
{
    public interface IGetAllProductsService
    {
        Task<ApplicationServiceQueryResponseEntity<List<ProductDto>>> ResponseAsync();
    }
}
