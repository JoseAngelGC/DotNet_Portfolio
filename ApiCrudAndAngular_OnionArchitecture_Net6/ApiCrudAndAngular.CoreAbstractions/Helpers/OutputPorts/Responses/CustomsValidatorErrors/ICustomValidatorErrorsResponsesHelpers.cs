using ApiCrudAndAngular.CoreAbstractions.CoreEntities.Dtos.OutputPortDtos.Responses;
using FluentValidation.Results;

namespace ApiCrudAndAngular.CoreAbstractions.Helpers.OutputPorts.Responses.CustomsValidatorErrors
{
    public interface ICustomValidatorErrorsResponsesHelpers
    {
        Task<CommandResponseDto> BasicCommandResponseHelperAsync(List<ValidationFailure> validationErrors);
        Task<QueryResponseDto<T>> BasicQueryResponseHelperAsync<T>(List<ValidationFailure> validationErrors);
    }
}
