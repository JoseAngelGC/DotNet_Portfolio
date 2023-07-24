using ApiCrudWithBlazor.BlazorClient.DomainModels.CoreAbstractions.Services;
using ApiCrudWithBlazor.BlazorClient.DomainModels.CoreEntities.ApiRequests;
using ApiCrudWithBlazor.BlazorClient.DomainModels.CoreEntities.ApiResponses;
using ApiCrudWithBlazor.BlazorClient.DomainModels.CoreEntities.Dtos;
using System.Net.Http.Json;

namespace ApiCrudWithBlazor.BlazorClient.DomainServices
{
    public class ProductApiService : IProductApiService
    {
        private readonly HttpClient _httpClient;
        public ProductApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ApiQueryResponse<List<ProductDto>>> ListAsync(CommonFiltersApiRequestDto filtersRequestDto)
        {
            var result = await _httpClient.PostAsJsonAsync("api/v1/Product/Products", filtersRequestDto);
            var response = await result.Content.ReadFromJsonAsync<ApiQueryResponse<List<ProductDto>>>();
            if (response!.IsSuccess)
            {
                return response;
            }
            else
            {
                throw new Exception(response.MessageResponse);
            }
        }

        public async Task<ApiQueryResponse<ProductDto>> SearchByIdAsync(int productId)
        {
            var result = await _httpClient.GetFromJsonAsync<ApiQueryResponse<ProductDto>>("api/v1/Product/Product/" + productId);
            if (result!.IsSuccess)
            {
                return result;
            }
            else
            {
                throw new Exception(result.MessageResponse);
            }
        }

        public async Task<ApiCommandResponse> RegisterAsync(ProductDto product)
        {
            var result = await _httpClient.PostAsJsonAsync("api/v1/Product/RegisterProduct", product);
            var response = await result.Content.ReadFromJsonAsync<ApiCommandResponse>();
            if (response!.IsSuccess)
            {
                return response;
            }
            else
            {
                throw new Exception(response.MessageResponse);
            }
        }

        public async Task<ApiCommandResponse> EditAsync(ProductDto product)
        {
            var result = await _httpClient.PutAsJsonAsync("api/v1/Product/EditProduct/" + product.IdProduct, product);
            var response = await result.Content.ReadFromJsonAsync<ApiCommandResponse>();
            if (response!.IsSuccess)
            {
                return response;
            }
            else
            {
                throw new Exception(response.MessageResponse);
            }
        }

        public async Task<ApiCommandResponse> DeleteAsync(int productId)
        {
            var result = await _httpClient.DeleteAsync("api/v1/Product/DeleteProduct/" + productId);
            var response = await result.Content.ReadFromJsonAsync<ApiCommandResponse>();
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
