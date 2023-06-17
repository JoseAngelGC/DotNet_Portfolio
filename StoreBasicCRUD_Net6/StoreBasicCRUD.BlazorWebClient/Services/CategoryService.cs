using StoreBasicCRUD.BlazorCoreStructure.Dtos;
using StoreBasicCRUD.BlazorCoreStructure.ResponsesApi;
using StoreBasicCRUD.BlazorWebClient.Services.Interfaces;
using System.Net.Http.Json;

namespace StoreBasicCRUD.BlazorWebClient.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _httpClient;
        public CategoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<QueryResponseApi<List<CategoryDto>>> ListaAsync()
        {
            var result = await _httpClient.GetFromJsonAsync<QueryResponseApi<List<CategoryDto>>>("api/v1/Category/Categories");
            if (result!.IsSuccess)
            {
                return result;
            }
            else
            {
                throw new Exception(result.MessageResponse);
            }
            
        }
    }
}
