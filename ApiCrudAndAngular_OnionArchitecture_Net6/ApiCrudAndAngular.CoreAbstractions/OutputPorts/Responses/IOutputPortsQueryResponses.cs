using ApiCrudAndAngular.CoreAbstractions.CoreEntities.Dtos.OutputPortDtos.Responses;

namespace ApiCrudAndAngular.CoreAbstractions.OutputPorts.Responses
{
    public interface IOutputPortsQueryResponses
    {
        //Query responses
        Task<QueryResponseDto<T>> SuccessfulBasicResponseAsync<T>(T data);
        Task<QueryResponseDto<T>> ExceptionBasicResponseAsync<T>(string? messageErrorException, int? hResultException, string? sourceException);
        Task<QueryResponseDto<T>> NotFoundErrorBasicResponseAsync<T>();
        Task<QueryResponseDto<T>> ServerErrorBasicResponseAsync<T>();
    }
}
