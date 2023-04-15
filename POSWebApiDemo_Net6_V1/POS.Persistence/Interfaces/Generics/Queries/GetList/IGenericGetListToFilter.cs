using POS.DomainSqlServer.EFCore.DatabaseFirst.Entities.BaseEntities;
using System.Linq.Expressions;

namespace POS.Persistence.Interfaces.Generics.Queries.GetList
{
    public interface IGenericGetListToFilter<T> where T : BaseEntity
    {
        Task<IQueryable<T>> GetQueryableEntityItemsAsync(Expression<Func<T, bool>>? filter = null);
    }
}
