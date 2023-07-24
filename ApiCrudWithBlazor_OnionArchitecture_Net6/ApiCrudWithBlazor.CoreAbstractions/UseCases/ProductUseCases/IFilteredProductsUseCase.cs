using ApiCrudWithBlazor.CoreAbstractions.CoreEntities.Dtos.ProductDtos;
using ApiCrudWithBlazor.CoreAbstractions.CoreEntities.Dtos.RequestsDtos;
using ApiCrudWithBlazor.CoreAbstractions.CoreEntities.Dtos.ResponsesDtos;
using ApiCrudWithBlazor.Entities.ApiCrud.EFCore.Bases;

namespace ApiCrudWithBlazor.CoreAbstractions.UseCases.ProductUseCases
{
    public interface IFilteredProductsUseCase<T> where T : BaseEntity
    {
        Task<QueryResponseDto<IQueryable<ProductDto>>> GetAllProductsByFiltersAsync(CommonFiltersRequestDto filters);
    }
}
