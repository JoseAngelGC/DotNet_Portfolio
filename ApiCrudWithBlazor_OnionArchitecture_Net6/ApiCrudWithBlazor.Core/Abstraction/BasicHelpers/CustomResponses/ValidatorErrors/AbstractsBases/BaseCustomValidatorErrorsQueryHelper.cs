using ApiCrudWithBlazor.CoreAbstractions.CoreEntities.Dtos.ResponsesDtos;
using FluentValidation.Results;

namespace ApiCrudWithBlazor.Core.Abstraction.BasicHelpers.CustomResponses.ValidatorErrors.AbstractsBases
{
    public abstract class BaseCustomValidatorErrorsQueryHelper
    {
        public abstract Task<QueryResponseDto<T>> AttributesValuesResponseAsync<T>(List<ValidationFailure> validationErrors);
    }
}
