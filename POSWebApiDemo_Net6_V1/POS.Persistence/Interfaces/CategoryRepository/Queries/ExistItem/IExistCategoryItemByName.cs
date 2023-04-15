namespace POS.Persistence.Interfaces.CategoryRepository.Queries.ExistItem
{
    public interface IExistCategoryItemByName
    {
        Task<bool> GetItemAsync(string name);
    }
}
