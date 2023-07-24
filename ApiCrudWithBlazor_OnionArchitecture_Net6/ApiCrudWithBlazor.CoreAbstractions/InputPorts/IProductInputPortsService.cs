using ApiCrudWithBlazor.CoreAbstractions.CoreEntities.Dtos.ProductDtos;
using ApiCrudWithBlazor.CoreAbstractions.CoreEntities.Dtos.RequestsDtos;
using ApiCrudWithBlazor.CoreAbstractions.CoreEntities.Dtos.ResponsesDtos;


namespace ApiCrudWithBlazor.CoreAbstractions.InputPorts
{
    public interface IProductInputPortsService
    {
        Task<QueryResponseDto<IQueryable<ProductDto>>> GetFilteredProductsAsync(CommonFiltersRequestDto filters);
        Task<QueryResponseDto<ProductDto>> GetProductByIdAsync(int id);
        Task<CommandResponseDto> CreateProductAsync(ProductRequestDto productRequestDto);
        Task<CommandResponseDto> EditProductAsync(int id, ProductRequestDto productRequestDto);
        Task<CommandResponseDto> DeleteProductAsync(int id);
    }
}
