

namespace POS.Persistence.Interfaces.CategoryRepository.Queries.ExistItem
{
    public interface IExistCategoryItemById
    {
        Task<bool> ResponseAsync(int id);
    }
}
