using StoreBasicCRUD.BlazorCoreStructure.Dtos;
using StoreBasicCRUD.BlazorCoreStructure.ResponsesApi;

namespace StoreBasicCRUD.BlazorWebClient.Services.Interfaces
{
    public interface IProductService
    {
        Task<QueryResponseApi<List<ProductDto>>> ListaAsync();
        Task<QueryResponseApi<ProductDto>> BuscarAsync(int productId);
        Task<CommandResponseApi> GuardarAsync(ProductDto product);
        Task<CommandResponseApi> ActualizarAsync(ProductDto product);
        Task<CommandResponseApi> EliminarAsync(int productId);
    }
}
