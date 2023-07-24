using ApiCrudWithBlazor.CoreAbstractions.CoreEntities.Dtos.ResponsesDtos;


namespace ApiCrudWithBlazor.Core.Abstraction.BasicHelpers.ExecutionFailsResponses.Exceptions
{
    public interface IExceptionResponseBasicsHelpersService
    {
        Task<CommandResponseDto> CommandExceptionHelperAsync(string? messageErrorException, int? hResultException, string? sourceException);
        Task<QueryResponseDto<T>> QueryExceptionHelperAsync<T>(string? messageErrorException, int? hResultException, string? sourceException);
    }
}
