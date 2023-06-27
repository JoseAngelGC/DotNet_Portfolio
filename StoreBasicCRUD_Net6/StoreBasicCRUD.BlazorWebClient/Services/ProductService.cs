using StoreBasicCRUD.BlazorCoreStructure.Dtos;
using StoreBasicCRUD.BlazorCoreStructure.ResponsesApi;
using StoreBasicCRUD.BlazorCoreStructure.ResquestsApi;
using StoreBasicCRUD.BlazorWebClient.Services.Interfaces;
using System.Net.Http.Json;

namespace StoreBasicCRUD.BlazorWebClient.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;
        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<QueryResponseApi<List<ProductDto>>> ListaAsync(CommonFiltersRequestDto filtersRequestDto)
        {
            var result = await _httpClient.PostAsJsonAsync("api/v1/Product/Products", filtersRequestDto);
            var response = await result.Content.ReadFromJsonAsync<QueryResponseApi<List<ProductDto>>>();
            if (response!.IsSuccess)
            {
                return response;
            }
            else
            {
                throw new Exception(response.MessageResponse);
            }
        }

        public async Task<QueryResponseApi<ProductDto>> BuscarProductoAsync(int productId)
        {
            var result = await _httpClient.GetFromJsonAsync<QueryResponseApi<ProductDto>>("api/v1/Product/Product/"+productId);
            if (result!.IsSuccess)
            {
                return result;
            }
            else
            {
                throw new Exception(result.MessageResponse);
            }
        }

        public async Task<CommandResponseApi> GuardarAsync(ProductDto product)
        {
            var result = await _httpClient.PostAsJsonAsync("api/v1/Product/RegisterProduct", product);
            var response = await result.Content.ReadFromJsonAsync<CommandResponseApi>();
            if (response!.IsSuccess)
            {
                return response;
            }
            else
            {
                throw new Exception(response.MessageResponse);
            }
        }

        public async Task<CommandResponseApi> ActualizarAsync(ProductDto product)
        {
            var result = await _httpClient.PutAsJsonAsync("api/v1/Product/EditProduct/" + product.IdProduct, product);
            var response = await result.Content.ReadFromJsonAsync<CommandResponseApi>();
            if (response!.IsSuccess)
            {
                return response;
            }
            else
            {
                throw new Exception(response.MessageResponse);
            }
        }

        public async Task<CommandResponseApi> EliminarAsync(int productId)
        {
            var result = await _httpClient.DeleteAsync("api/v1/Product/DeleteProduct/" + productId);
            var response = await result.Content.ReadFromJsonAsync<CommandResponseApi>();
            if (response!.IsSuccess)
            {
                return response;
            }
            else
            {
                throw new Exception(response.MessageResponse);
            }
        }

    }
}
