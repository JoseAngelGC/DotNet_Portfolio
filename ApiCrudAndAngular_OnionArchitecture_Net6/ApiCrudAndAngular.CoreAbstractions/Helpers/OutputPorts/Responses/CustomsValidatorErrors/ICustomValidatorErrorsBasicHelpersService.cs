using ApiCrudAndAngular.CoreAbstractions.CoreEntities.Dtos.OutputPortDtos.Responses;
using FluentValidation.Results;

namespace ApiCrudAndAngular.CoreAbstractions.Helpers.OutputPorts.Responses.CustomsValidatorErrors
{
    public interface ICustomValidatorErrorsBasicHelpersService
    {
        Task<CommandResponseDto> CommandResponseHelperAsync(List<ValidationFailure> validationErrors);
        Task<QueryResponseDto<T>> QueryResponseHelperAsync<T>(List<ValidationFailure> validationErrors);
    }
}
