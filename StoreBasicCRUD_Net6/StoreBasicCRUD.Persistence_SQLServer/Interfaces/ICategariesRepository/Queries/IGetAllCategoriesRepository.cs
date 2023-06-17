using StoreBasicCRUD.SQLServer_Entities.EFCore.DataBaseFirst.Entities;

namespace StoreBasicCRUD.Persistence_SQLServer.Interfaces.ICategariesRepository.Queries
{
    public interface IGetAllCategoriesRepository
    {
        Task<List<Category>> ResponsesAsync();
    }
}
