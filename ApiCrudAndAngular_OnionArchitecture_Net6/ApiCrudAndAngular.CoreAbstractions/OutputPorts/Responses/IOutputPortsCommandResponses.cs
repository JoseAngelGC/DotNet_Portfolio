using ApiCrudAndAngular.CoreAbstractions.CoreEntities.Dtos.OutputPortDtos.Responses;
using FluentValidation.Results;

namespace ApiCrudAndAngular.CoreAbstractions.OutputPorts.Responses
{
    public interface IOutputPortsCommandResponses
    {
        //Command responses
        Task<CommandResponseDto> SuccessfulResponseHelperAsync(int? recordsAffected, string messageResponse);
        Task<CommandResponseDto> ExceptionResponseHelperAsync(string? messageErrorException, int? hResultException, string? sourceException);
        Task<CommandResponseDto> NotFoundDataErrorResponseHelperAsync();
        Task<CommandResponseDto> ExistingRecordErrorResponseHelperAsync();
        Task<CommandResponseDto> ServerErrorResponseHelperAsync();
        Task<CommandResponseDto> CustomValidatorErrorsResponseHelperAsync(List<ValidationFailure> validationErrors);

    }
}
