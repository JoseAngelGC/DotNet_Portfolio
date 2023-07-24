using ApiCrudWithBlazor.CoreAbstractions.CoreEntities.Dtos.ProductDtos;
using ApiCrudWithBlazor.Entities.ApiCrud.EFCore.Bases;


namespace ApiCrudWithBlazor.CoreAbstractions.Repositories.ProductRepositories.Queries
{
    public interface IGetProductDtoByIdRepository<T> where T : BaseEntity
    {
        Task<ProductDto> QueryAsync(int id);
    }
}
