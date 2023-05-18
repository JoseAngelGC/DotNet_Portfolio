

namespace POS.Persistence.Interfaces.UserRepository.Queries.ExistItem
{
    public interface IExistUserItemByNameRepository
    {
        Task<bool> ExistItemAsync(string name);
    }
}
