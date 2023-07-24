using ApiCrudWithBlazor.Entities.ApiCrud.EFCore.Bases;

namespace ApiCrudWithBlazor.CoreAbstractions.Repositories.Generic.Queries
{
    public interface IExistingRecordGenericRepository<T> where T : BaseEntity
    {
        Task<bool> QueryAsync(string commandAction, T entity);
    }
}
