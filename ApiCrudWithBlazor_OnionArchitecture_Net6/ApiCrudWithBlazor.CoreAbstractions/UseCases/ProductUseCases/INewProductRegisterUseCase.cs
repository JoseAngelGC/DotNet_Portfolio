using ApiCrudWithBlazor.CoreAbstractions.CoreEntities.Dtos.RequestsDtos;
using ApiCrudWithBlazor.CoreAbstractions.CoreEntities.Dtos.ResponsesDtos;
using ApiCrudWithBlazor.Entities.ApiCrud.EFCore.Bases;


namespace ApiCrudWithBlazor.CoreAbstractions.UseCases.ProductUseCases
{
    public interface INewProductRegisterUseCase<T> where T : BaseEntity
    {
        Task<CommandResponseDto> CreateRecordAsync(ProductRequestDto productRequestDto);
    }
}
