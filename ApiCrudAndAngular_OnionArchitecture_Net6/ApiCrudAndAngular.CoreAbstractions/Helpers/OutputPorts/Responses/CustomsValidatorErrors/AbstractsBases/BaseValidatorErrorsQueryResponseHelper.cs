using ApiCrudAndAngular.CoreAbstractions.CoreEntities.Dtos.OutputPortDtos.Responses;
using FluentValidation.Results;

namespace ApiCrudAndAngular.CoreAbstractions.Helpers.OutputPorts.Responses.CustomsValidatorErrors.AbstractsBases
{
    public abstract class BaseValidatorErrorsQueryResponseHelper
    {
        public abstract Task<QueryResponseDto<T>> CustomAttributesValuesAsync<T>(List<ValidationFailure> validationErrors);
    }
}
