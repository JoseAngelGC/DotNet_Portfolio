using POS.DomainSqlServer.EFCore.DatabaseFirst.Entities.BaseEntities;
using POS.Persistence.Interfaces.Generics.Queries.GetItem;
using POS.Persistence.Interfaces.Generics.Queries.GetList;

namespace POS.Persistence.Interfaces.UnitsOfWork.CategoryUnitsOfWork
{
    public interface ICategoryRepositoryQueriesUnitsOfWork<T> : IDisposable where T : BaseEntity
    {
        IGenericGetListToFilter<T> GenericGetListToFiter { get; }
        IGenericGetAllList<T> GenericGetAllList { get; }
        IGenericGetEntityItemById<T> GenericGetEntityItemById { get; }
        void SaveChanges();
        Task SaveChangesAsync();
    }
}
