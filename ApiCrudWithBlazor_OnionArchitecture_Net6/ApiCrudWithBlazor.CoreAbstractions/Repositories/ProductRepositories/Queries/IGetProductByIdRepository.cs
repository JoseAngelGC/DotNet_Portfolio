using ApiCrudWithBlazor.Entities.ApiCrud.EFCore;
using ApiCrudWithBlazor.Entities.ApiCrud.EFCore.Bases;


namespace ApiCrudWithBlazor.CoreAbstractions.Repositories.ProductRepositories.Queries
{
    public interface IGetProductByIdRepository<T> where T : BaseEntity
    {
        Task<Product> QueryAsync(int id);
    }
}
