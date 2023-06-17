using StoreBasicCRUD.BlazorCoreStructure.Dtos;
using StoreBasicCRUD.BlazorCoreStructure.ResponsesApi;

namespace StoreBasicCRUD.BlazorWebClient.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<QueryResponseApi<List<CategoryDto>>> ListaAsync();
    }
}
