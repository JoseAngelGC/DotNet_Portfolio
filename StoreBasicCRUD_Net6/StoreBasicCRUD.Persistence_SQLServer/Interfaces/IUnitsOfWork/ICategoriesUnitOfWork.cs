using StoreBasicCRUD.Persistence_SQLServer.Interfaces.ICategariesRepository.Queries;


namespace StoreBasicCRUD.Persistence_SQLServer.Interfaces.IUnitsOfWork
{
    public interface ICategoriesUnitOfWork<T> where T : class
    {
        IGetAllCategoriesRepository GetCategoriesRepository { get; }
        IGetCategoryByCategoryNameRepository GetCategoryByNameRepository { get; }
    }
}
