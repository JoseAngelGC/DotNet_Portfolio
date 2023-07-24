using ApiCrudWithBlazor.CoreAbstractions.CoreEntities.Dtos.RequestsDtos;
using ApiCrudWithBlazor.CoreAbstractions.CoreEntities.Dtos.ResponsesDtos;
using ApiCrudWithBlazor.Entities.ApiCrud.EFCore.Bases;


namespace ApiCrudWithBlazor.CoreAbstractions.UseCases.ProductUseCases
{
    public interface IProductEditUseCase<T> where T : BaseEntity
    {
        Task<CommandResponseDto> ModifyRecordAsync(ProductRequestPivotDto productRequestPivotDto);
    }
}
