using StoreBasicCRUD.ApplicationCoreStructure.ApplicationDtos.Categories.EntitiesDtos;
using StoreBasicCRUD.ApplicationCoreStructure.ApplicationDtos.Shared.ServiceResponses.Queries;

namespace StoreBasicCRUD.ApplicationServices.Interfaces.CategoryServices.Queries
{
    public interface IGetAllCategoriesService
    {
        Task<ApplicationServiceQueryResponseDto<List<CategoryDto>>> ResponseAsync();
    }
}
