using ApiCrudWithBlazor.Entities.ApiCrud.EFCore.Bases;


namespace ApiCrudWithBlazor.CoreAbstractions.Repositories.Generic.Queries
{
    public interface IGetAllGenericRepository<T> where T : BaseEntity
    {
        Task<IQueryable<T>> QueryAsync();
    }
}
