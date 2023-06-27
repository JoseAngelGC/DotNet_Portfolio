using StoreBasicCRUD.ApplicationCoreStructure.ApplicationDtos.Products.RequestDtos;
using StoreBasicCRUD.ApplicationCoreStructure.ApplicationDtos.Shared.ServiceResponses.Commands;

namespace StoreBasicCRUD.ApplicationServices.Interfaces.ProductsServices.Commands
{
    public interface ISaveProductService
    {
        Task<ApplicationServiceCommandResponseDto> ResponseAsync(ProductRequestDto requestDto);
    }
}
