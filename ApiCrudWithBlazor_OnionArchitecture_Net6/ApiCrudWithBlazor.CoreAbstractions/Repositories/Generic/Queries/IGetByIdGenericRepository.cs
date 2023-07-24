using ApiCrudWithBlazor.Entities.ApiCrud.EFCore.Bases;

namespace ApiCrudWithBlazor.CoreAbstractions.Repositories.Generic.Queries
{
    public interface IGetByIdGenericRepository<T> where T : BaseEntity
    {
        Task<T> QueryAsync(int id);
    }
}
