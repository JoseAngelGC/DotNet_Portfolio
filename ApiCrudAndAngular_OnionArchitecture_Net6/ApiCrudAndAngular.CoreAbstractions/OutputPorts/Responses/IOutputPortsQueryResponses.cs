using ApiCrudAndAngular.CoreAbstractions.CoreEntities.Dtos.OutputPortDtos.Responses;
using FluentValidation.Results;

namespace ApiCrudAndAngular.CoreAbstractions.OutputPorts.Responses
{
    public interface IOutputPortsQueryResponses
    {
        //Query responses
        Task<QueryResponseDto<T>> SuccessfulResponseHelperAsync<T>(T data);
        Task<QueryResponseDto<T>> ExceptionResponseHelperAsync<T>(string? messageErrorException, int? hResultException, string? sourceException);
        Task<QueryResponseDto<T>> NotFoundDataErrorResponseHelperAsync<T>();
        Task<QueryResponseDto<T>> ServerErrorResponseHelperAsync<T>();
        Task<QueryResponseDto<T>> CustomValidatorErrorsResponseHelperAsync<T>(List<ValidationFailure> validationErrors);
    }
}
