using ApiCrudWithBlazor.CoreAbstractions.CoreEntities.Dtos.ResponsesDtos;
using FluentValidation.Results;

namespace ApiCrudWithBlazor.Core.Abstraction.BasicHelpers.CustomResponses.ValidatorErrors.AbstractsBases
{
    public abstract class BaseCustomValidatorErrorsCommandHelper
    {
        public abstract Task<CommandResponseDto> AttributesValuesResponseAsync(List<ValidationFailure> validationErrors);
    }
}
