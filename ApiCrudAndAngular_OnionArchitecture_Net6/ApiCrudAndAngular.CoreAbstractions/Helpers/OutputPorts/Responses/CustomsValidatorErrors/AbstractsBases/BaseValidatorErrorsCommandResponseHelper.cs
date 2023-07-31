using ApiCrudAndAngular.CoreAbstractions.CoreEntities.Dtos.OutputPortDtos.Responses;
using FluentValidation.Results;

namespace ApiCrudAndAngular.CoreAbstractions.Helpers.OutputPorts.Responses.CustomsValidatorErrors.AbstractsBases
{
    public abstract class BaseValidatorErrorsCommandResponseHelper
    {
        public abstract Task<CommandResponseDto> CustomAttributesValuesAsync(List<ValidationFailure> validationErrors);
    }
}
