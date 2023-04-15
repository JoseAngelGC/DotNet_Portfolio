using POS.DomainSqlServer.EFCore.DatabaseFirst.Entities.BaseEntities;
using POS.Infraestructure.SupportEntities.Persistence.Commons.Commands.Responses;


namespace POS.Persistence.Interfaces.Generics.Commands.SaveItem
{
    public interface IGenericSaveEntityItem<T> where T : BaseEntity
    {
        Task<ExecutedCommandEntity> SaveItemAsync(T entity);
    }
}
