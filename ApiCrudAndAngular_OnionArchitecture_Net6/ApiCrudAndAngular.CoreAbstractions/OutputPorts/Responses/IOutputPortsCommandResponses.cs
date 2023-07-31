using ApiCrudAndAngular.CoreAbstractions.CoreEntities.Dtos.OutputPortDtos.Responses;

namespace ApiCrudAndAngular.CoreAbstractions.OutputPorts.Responses
{
    public interface IOutputPortsCommandResponses
    {
        //Command responses
        Task<CommandResponseDto> SuccessfulBasicResponseAsync(int? recordsAffected, string messageResponse);
        Task<CommandResponseDto> ExceptionBasicResponseAsync(string? messageErrorException, int? hResultException, string? sourceException);
        Task<CommandResponseDto> NotFoundErrorBasicResponseAsync();
        Task<CommandResponseDto> ExistingRecordErrorBasicResponseAsync();
        Task<CommandResponseDto> ServerErrorBasicResponseAsync();

    }
}
