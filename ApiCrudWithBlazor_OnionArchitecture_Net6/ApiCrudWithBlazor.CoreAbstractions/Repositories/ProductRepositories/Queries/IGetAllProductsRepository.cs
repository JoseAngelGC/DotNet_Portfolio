using ApiCrudWithBlazor.CoreAbstractions.CoreEntities.Dtos.ProductDtos;
using ApiCrudWithBlazor.Entities.ApiCrud.EFCore.Bases;

namespace ApiCrudWithBlazor.CoreAbstractions.Repositories.ProductRepositories.Queries
{
    public interface IGetAllProductsRepository<T> where T : BaseEntity
    {
        Task<IQueryable<ProductDto>> QueryMultiTableAsync();
    }
}
