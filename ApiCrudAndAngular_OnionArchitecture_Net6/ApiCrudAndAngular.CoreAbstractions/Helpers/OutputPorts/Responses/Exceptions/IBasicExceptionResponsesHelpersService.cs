using ApiCrudAndAngular.CoreAbstractions.CoreEntities.Dtos.OutputPortDtos.Responses;

namespace ApiCrudAndAngular.CoreAbstractions.Helpers.OutputPorts.Responses.Exceptions
{
    public interface IBasicExceptionResponsesHelpersService
    {
        Task<CommandResponseDto> CommandResponseHelperAsync(string? messageErrorException, int? hResultException, string? sourceException);
        Task<QueryResponseDto<T>> QueryResponseHelperAsync<T>(string? messageErrorException, int? hResultException, string? sourceException);
    }
}
