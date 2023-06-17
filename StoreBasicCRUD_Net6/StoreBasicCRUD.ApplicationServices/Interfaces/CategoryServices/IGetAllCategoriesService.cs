using StoreBasicCRUD.ApplicationCoreStructure.ApplicationDtos.Categories.EntitiesDtos;
using StoreBasicCRUD.ApplicationCoreStructure.ApplicationEntities.Responses.Queries;


namespace StoreBasicCRUD.ApplicationServices.Interfaces.CategoryServices
{
    public interface IGetAllCategoriesService
    {
        Task<ApplicationServiceQueryResponseEntity<List<CategoryDto>>> ResponseAsync();
    }
}
