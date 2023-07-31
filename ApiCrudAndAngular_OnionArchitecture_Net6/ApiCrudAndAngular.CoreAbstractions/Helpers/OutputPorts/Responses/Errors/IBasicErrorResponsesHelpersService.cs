using ApiCrudAndAngular.CoreAbstractions.CoreEntities.Dtos.OutputPortDtos.Responses;

namespace ApiCrudAndAngular.CoreAbstractions.Helpers.OutputPorts.Responses.Errors
{
    public interface IBasicErrorResponsesHelpersService
    {
        Task<CommandResponseDto> NotFoundDataCommandResponseHelperAsync();
        Task<CommandResponseDto> ExistingRecordCommandResponseHelperAsync();
        Task<CommandResponseDto> ServerErrorCommandResponseHelperAsync();
        Task<QueryResponseDto<T>> NotFoundDataQueryResponseHelperAsync<T>();
        Task<QueryResponseDto<T>> ServerErrorQueryResponseHelperAsync<T>();
    }
}
