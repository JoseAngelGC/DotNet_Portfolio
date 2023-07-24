using ApiCrudWithBlazor.CoreAbstractions.CoreEntities.Dtos.ProductDtos;
using ApiCrudWithBlazor.CoreAbstractions.CoreEntities.Dtos.ResponsesDtos;
using ApiCrudWithBlazor.Entities.ApiCrud.EFCore.Bases;

namespace ApiCrudWithBlazor.CoreAbstractions.UseCases.ProductUseCases
{
    public interface IShowProductUseCase<T> where T : BaseEntity
    {
        Task<QueryResponseDto<ProductDto>> GetByIdAsync(int id);
    }
}
