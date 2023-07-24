using ApiCrudWithBlazor.CoreAbstractions.CoreEntities.Dtos.ResponsesDtos;
using FluentValidation.Results;

namespace ApiCrudWithBlazor.Core.Abstraction.BasicHelpers.CustomResponses
{
    public interface ICustomErrorResponsesBasicsHelpersService
    {
        Task<CommandResponseDto> ValidatorErrorsCommandBasicHelperAsync(List<ValidationFailure> validationErrors);
        Task<QueryResponseDto<T>> ValidatorErrorsQueryBasicHelperAsync<T>(List<ValidationFailure> validationErrors);
    }
}
