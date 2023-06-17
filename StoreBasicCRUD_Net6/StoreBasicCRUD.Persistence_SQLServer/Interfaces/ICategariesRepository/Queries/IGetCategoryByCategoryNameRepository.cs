using StoreBasicCRUD.SQLServer_Entities.EFCore.DataBaseFirst.Entities;

namespace StoreBasicCRUD.Persistence_SQLServer.Interfaces.ICategariesRepository.Queries
{
    public interface IGetCategoryByCategoryNameRepository
    {
        Task<Category> ResponseAsync(string categoryName);
    }
}
