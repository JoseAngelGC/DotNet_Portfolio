using ApiCrudWithBlazor.CoreAbstractions.CoreEntities.Dtos.ResponsesDtos;
using FluentValidation.Results;

namespace ApiCrudWithBlazor.CoreAbstractions.OutputPorts
{
    public interface IResponsesOutputPortsBasicHelpersHub
    {
        //Query responses
        Task<QueryResponseDto<T>> SuccessfulQueryBasicHelperAsync<T>(T data);
        Task<QueryResponseDto<T>> ExceptionQueryBasicHelperAsync<T>(string? messageErrorException, int? hResultException, string? sourceException);
        Task<QueryResponseDto<T>> NotFoundErrorQueryBasicHelperAsync<T>();
        Task<QueryResponseDto<T>> ServerErrorQueryBasicHelperAsync<T>();
        Task<QueryResponseDto<T>> ValidatorErrorsQueryBasicHelperAsync<T>(List<ValidationFailure> validationErrors);

        //Command responses
        Task<CommandResponseDto> SuccessfulCommandBasicHelperAsync(int? recordsAffected, string messageResponse);
        Task<CommandResponseDto> ExceptionCommandBasicHelperAsync(string? messageErrorException, int? hResultException, string? sourceException);
        Task<CommandResponseDto> NotFoundErrorCommandBasicHelperAsync();
        Task<CommandResponseDto> RecordExistErrorCommandBasicHelperAsync();
        Task<CommandResponseDto> ServerErrorCommandBasicHelperAsync();
        Task<CommandResponseDto> ValidatorErrorsCommandBasicHelperAsync(List<ValidationFailure> validationErrors);
    }
}
