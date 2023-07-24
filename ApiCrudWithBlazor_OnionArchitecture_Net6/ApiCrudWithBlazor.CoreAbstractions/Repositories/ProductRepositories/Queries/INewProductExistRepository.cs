using ApiCrudWithBlazor.CoreAbstractions.CoreEntities.Dtos.RequestsDtos;
using ApiCrudWithBlazor.Entities.ApiCrud.EFCore.Bases;


namespace ApiCrudWithBlazor.CoreAbstractions.Repositories.ProductRepositories.Queries
{
    public interface INewProductExistRepository<T> where T : BaseEntity
    {
        Task<bool> QueryAsync(string recordAction, ProductRequestPivotDto entity);
    }
}
