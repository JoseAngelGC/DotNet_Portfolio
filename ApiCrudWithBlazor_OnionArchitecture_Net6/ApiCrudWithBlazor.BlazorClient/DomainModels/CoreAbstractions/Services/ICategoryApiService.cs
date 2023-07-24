using ApiCrudWithBlazor.BlazorClient.DomainModels.CoreEntities.ApiResponses;
using ApiCrudWithBlazor.BlazorClient.DomainModels.CoreEntities.Dtos;

namespace ApiCrudWithBlazor.BlazorClient.DomainModels.CoreAbstractions.Services
{
    public interface ICategoryApiService
    {
        Task<ApiQueryResponse<List<CategoryDto>>> ListAsync();
    }
}
