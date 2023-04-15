using POS.DomainSqlServer.EFCore.DatabaseFirst.Entities.BaseEntities;


namespace POS.Persistence.Interfaces.Generics.Queries.GetItem
{
    public interface IGenericGetEntityItemById<T> where T : BaseEntity
    {
        Task<T> GetItemAsync(int id);
    }
}
