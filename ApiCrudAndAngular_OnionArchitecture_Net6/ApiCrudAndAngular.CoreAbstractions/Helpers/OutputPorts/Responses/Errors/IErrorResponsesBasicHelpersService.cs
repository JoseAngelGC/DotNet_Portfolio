using ApiCrudAndAngular.CoreAbstractions.CoreEntities.Dtos.OutputPortDtos.Responses;

namespace ApiCrudAndAngular.CoreAbstractions.Helpers.OutputPorts.Responses.Errors
{
    public interface IErrorResponsesBasicHelpersService
    {
        Task<CommandResponseDto> NotFoundDataErrorCommandResponseHelperAsync();
        Task<CommandResponseDto> ExistingRecordErrorCommandResponseHelperAsync();
        Task<CommandResponseDto> ServerErrorCommandResponseHelperAsync();
        Task<QueryResponseDto<T>> NotFoundDataErrorQueryResponseHelperAsync<T>();
        Task<QueryResponseDto<T>> ServerErrorQueryResponseHelperAsync<T>();
    }
}
