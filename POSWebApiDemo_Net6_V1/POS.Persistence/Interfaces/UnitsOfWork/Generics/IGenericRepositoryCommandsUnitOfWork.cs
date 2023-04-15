using POS.DomainSqlServer.EFCore.DatabaseFirst.Entities.BaseEntities;
using POS.Persistence.Interfaces.Generics.Commands.RemoveItem;
using POS.Persistence.Interfaces.Generics.Commands.SaveItem;
using POS.Persistence.Interfaces.Generics.Commands.UpdateItem;


namespace POS.Persistence.Interfaces.UnitsOfWork.Generics
{
    public interface IGenericRepositoryCommandsUnitOfWork<T> : IDisposable where T : BaseEntity
    {
        IGenericSaveEntityItem<T> GenericSaveEntityItem { get; }
        IGenericUpdateEntityItem<T> GenericUpdateEntityItem { get; }
        IGenericRemoveEntityItem<T> GenericRemoveEntityItem { get; }
        void SaveChanges();
        Task SaveChangesAsync();
    }
}
