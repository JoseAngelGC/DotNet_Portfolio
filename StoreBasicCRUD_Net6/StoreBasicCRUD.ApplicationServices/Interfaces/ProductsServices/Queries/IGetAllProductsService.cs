using StoreBasicCRUD.ApplicationCoreStructure.ApplicationDtos.Products.EntitiesDtos;
using StoreBasicCRUD.ApplicationCoreStructure.ApplicationDtos.Shared.Requests;
using StoreBasicCRUD.ApplicationCoreStructure.ApplicationDtos.Shared.ServiceResponses.Queries;

namespace StoreBasicCRUD.ApplicationServices.Interfaces.ProductsServices.Queries
{
    public interface IGetAllProductsService
    {
        Task<ApplicationServiceQueryResponseDto<List<ProductDto>>> ResponseAsync(CommonFiltersRequestDto productFiltersRequestDto);
    }
}
