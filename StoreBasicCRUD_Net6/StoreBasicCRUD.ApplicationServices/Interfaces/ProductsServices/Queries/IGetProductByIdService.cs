using StoreBasicCRUD.ApplicationCoreStructure.ApplicationDtos.Products.EntitiesDtos;
using StoreBasicCRUD.ApplicationCoreStructure.ApplicationDtos.Shared.ServiceResponses.Queries;

namespace StoreBasicCRUD.ApplicationServices.Interfaces.ProductsServices.Queries
{
    public interface IGetProductByIdService
    {
        Task<ApplicationServiceQueryResponseDto<ProductDto>> ResponseAsync(int productId);
    }
}
