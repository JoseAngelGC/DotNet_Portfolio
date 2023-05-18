using POS.DomainSqlServer.EFCore.DatabaseFirst.Entities;
using POS.Persistence.Interfaces.Generics.Commands.SaveItem;
using POS.Persistence.Interfaces.UserRepository.Queries.ExistItem;

namespace POS.Persistence.Interfaces.UnitsOfWork.UserUnitsOfWork
{
    public interface IUserCommandsUnitOfWork<T> : IDisposable where T : User
    {
        public IGenericSaveEntityItem<T> GenericSaveEntityItem { get; }
        public IExistUserItemByNameRepository ExistUserItemByName { get; }
        void SaveChanges();
        Task SaveChangesAsync();
    }
}
