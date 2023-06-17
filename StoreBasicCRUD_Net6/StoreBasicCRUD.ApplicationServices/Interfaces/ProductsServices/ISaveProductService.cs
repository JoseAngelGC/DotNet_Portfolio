using StoreBasicCRUD.ApplicationCoreStructure.ApplicationDtos.Products.RequestDtos;
using StoreBasicCRUD.ApplicationCoreStructure.ApplicationEntities.Responses.Commands;

namespace StoreBasicCRUD.ApplicationServices.Interfaces.ProductsServices
{
    public interface ISaveProductService
    {
        Task<ApplicationServiceCommandResponseEntity> ResponseAsync(ProductRequestDto requestDto);
    }
}
