using POS.DomainSqlServer.EFCore.DatabaseFirst.Entities.BaseEntities;


namespace POS.Persistence.Interfaces.Generics.Queries.GetList
{
    public interface IGenericGetAllList<T> where T : BaseEntity
    {
        Task<IQueryable<T>> GetQueryableAsync();
    }
}
