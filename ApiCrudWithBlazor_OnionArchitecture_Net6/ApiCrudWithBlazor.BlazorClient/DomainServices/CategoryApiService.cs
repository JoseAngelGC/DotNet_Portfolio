using ApiCrudWithBlazor.BlazorClient.DomainModels.CoreAbstractions.Services;
using ApiCrudWithBlazor.BlazorClient.DomainModels.CoreEntities.ApiResponses;
using ApiCrudWithBlazor.BlazorClient.DomainModels.CoreEntities.Dtos;
using System.Net.Http.Json;

namespace ApiCrudWithBlazor.BlazorClient.DomainServices
{
    public class CategoryApiService : ICategoryApiService
    {
        private readonly HttpClient _httpClient;
        public CategoryApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ApiQueryResponse<List<CategoryDto>>> ListAsync()
        {
            var result = await _httpClient.GetFromJsonAsync<ApiQueryResponse<List<CategoryDto>>>("api/v1/Category/Categories");
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
