using StoreBasicCRUD.BlazorCoreStructure.Dtos;
using StoreBasicCRUD.BlazorCoreStructure.ResponsesApi;
using StoreBasicCRUD.BlazorCoreStructure.ResquestsApi;

namespace StoreBasicCRUD.BlazorWebClient.Services.Interfaces
{
    public interface IProductService
    {
        Task<QueryResponseApi<List<ProductDto>>> ListaAsync(CommonFiltersRequestDto filtersRequestDto);
        Task<QueryResponseApi<ProductDto>> BuscarProductoAsync(int productId);
        Task<CommandResponseApi> GuardarAsync(ProductDto product);
        Task<CommandResponseApi> ActualizarAsync(ProductDto product);
        Task<CommandResponseApi> EliminarAsync(int productId);
    }
}
