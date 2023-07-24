using ApiCrudWithBlazor.CoreAbstractions.CoreEntities.Dtos.ResponsesDtos;


namespace ApiCrudWithBlazor.Core.Abstraction.BasicHelpers.CompletedExecutionResponses.Success
{
    public interface ISuccessfulResponseBasicsHelpersService
    {
        Task<CommandResponseDto> SuccessfulCommandBasicHelperAsync(int? recordsAffected, string messageResponse);
        Task<QueryResponseDto<T>> SuccessfulQueryBasicHelperAsync<T>(T data);
    }
}
