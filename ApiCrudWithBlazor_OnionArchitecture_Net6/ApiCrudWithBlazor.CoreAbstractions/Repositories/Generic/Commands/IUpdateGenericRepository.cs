using ApiCrudWithBlazor.Entities.ApiCrud.EFCore.Bases;

namespace ApiCrudWithBlazor.CoreAbstractions.Repositories.Generic.Commands
{
    public interface IUpdateGenericRepository<T> where T : BaseEntity
    {
        Task<int> CommandAsync(T entity);
    }
}
