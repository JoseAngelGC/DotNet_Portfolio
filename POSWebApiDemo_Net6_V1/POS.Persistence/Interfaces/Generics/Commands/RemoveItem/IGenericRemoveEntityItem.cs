using POS.DomainSqlServer.EFCore.DatabaseFirst.Entities.BaseEntities;
using POS.Infraestructure.SupportEntities.Persistence.Commons.Commands.Responses;


namespace POS.Persistence.Interfaces.Generics.Commands.RemoveItem
{
    public interface IGenericRemoveEntityItem<T> where T : BaseEntity
    {
        Task<ExecutedCommandEntity> RemoveItemAsync(T entity);
    }
}
