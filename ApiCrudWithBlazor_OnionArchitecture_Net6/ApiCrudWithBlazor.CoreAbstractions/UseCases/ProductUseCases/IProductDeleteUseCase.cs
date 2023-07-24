using ApiCrudWithBlazor.CoreAbstractions.CoreEntities.Dtos.ResponsesDtos;
using ApiCrudWithBlazor.Entities.ApiCrud.EFCore.Bases;


namespace ApiCrudWithBlazor.CoreAbstractions.UseCases.ProductUseCases
{
    public interface IProductDeleteUseCase<T> where T : BaseEntity
    {
        Task<CommandResponseDto> ModifyRecordAsync(int id);
    }
}
