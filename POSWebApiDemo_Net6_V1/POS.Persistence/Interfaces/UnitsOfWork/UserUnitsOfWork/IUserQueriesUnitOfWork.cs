using POS.DomainSqlServer.EFCore.DatabaseFirst.Entities.BaseEntities;
using POS.Persistence.Interfaces.UserRepository.Queries.GetItem;

namespace POS.Persistence.Interfaces.UnitsOfWork.UserUnitsOfWork
{
    public interface IUserQueriesUnitOfWork<T> : IDisposable where T : BaseEntity
    {
        IAccountByUserNameRepository<T> AccountByUserName { get; }
        void SaveChanges();
        Task SaveChangesAsync();
    }
}
