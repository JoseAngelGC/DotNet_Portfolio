using POS.DomainSqlServer.EFCore.DatabaseFirst.Entities.BaseEntities;
using POS.Infraestructure.SupportEntities.Persistence.Commons.Commands.Responses;


namespace POS.Persistence.Interfaces.Generics.Commands.UpdateItem
{
    public interface IGenericUpdateEntityItem<T> where T : BaseEntity
    {
        Task<ExecutedCommandEntity> UpdateItemAsync(T entity);
    }
}
