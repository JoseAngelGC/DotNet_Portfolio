using POS.DomainSqlServer.EFCore.DatabaseFirst.Entities.BaseEntities;

namespace POS.Persistence.Interfaces.UserRepository.Queries.GetItem
{
    public interface IAccountByUserNameRepository<T> where T : BaseEntity
    {
        Task<T> GetUserAccountAsync(string name);
    }
}
