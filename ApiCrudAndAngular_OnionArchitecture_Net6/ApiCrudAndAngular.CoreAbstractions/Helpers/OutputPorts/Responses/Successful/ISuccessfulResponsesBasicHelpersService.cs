using ApiCrudAndAngular.CoreAbstractions.CoreEntities.Dtos.OutputPortDtos.Responses;

namespace ApiCrudAndAngular.CoreAbstractions.Helpers.OutputPorts.Responses.Successful
{
    public interface ISuccessfulResponsesBasicHelpersService
    {
        Task<CommandResponseDto> CommandResponseHelperAsync(int? recordsAffected, string messageResponse);
        Task<QueryResponseDto<T>> QueryResponseHelperAsync<T>(T data);
    }
}
