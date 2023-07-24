using ApiCrudWithBlazor.BlazorClient.DomainModels.CoreEntities.ApiRequests;
using ApiCrudWithBlazor.BlazorClient.DomainModels.CoreEntities.ApiResponses;
using ApiCrudWithBlazor.BlazorClient.DomainModels.CoreEntities.Dtos;

namespace ApiCrudWithBlazor.BlazorClient.DomainModels.CoreAbstractions.Services
{
    public interface IProductApiService
    {
        Task<ApiQueryResponse<List<ProductDto>>> ListAsync(CommonFiltersApiRequestDto filtersRequestDto);
        Task<ApiQueryResponse<ProductDto>> SearchByIdAsync(int productId);
        Task<ApiCommandResponse> RegisterAsync(ProductDto product);
        Task<ApiCommandResponse> EditAsync(ProductDto product);
        Task<ApiCommandResponse> DeleteAsync(int productId);
    }
}
