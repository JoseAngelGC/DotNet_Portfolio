using ApiCrudWithBlazor.CoreAbstractions.CoreEntities.Dtos.ResponsesDtos;


namespace ApiCrudWithBlazor.Core.Abstraction.BasicHelpers.ExecutionFailsResponses.Errors
{
    public interface IErrorResponseBasicsHelpersService
    {
        Task<CommandResponseDto> CommandNotFoundErrorBasicHelperAsync();
        Task<CommandResponseDto> CommandExistingRecordErrorBasicHelperAsync();
        Task<CommandResponseDto> CommandServerErrorBasicHelperAsync();
        Task<QueryResponseDto<T>> QueryNotFoundErrorBasicHelperAsync<T>();
        Task<QueryResponseDto<T>> QueryServerErrorBasicHelperAsync<T>();

    }
}
