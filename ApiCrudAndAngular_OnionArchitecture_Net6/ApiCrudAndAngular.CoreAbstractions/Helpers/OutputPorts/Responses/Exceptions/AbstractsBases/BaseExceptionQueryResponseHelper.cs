using ApiCrudAndAngular.CoreAbstractions.CoreEntities.Dtos.OutputPortDtos.Responses;

namespace ApiCrudAndAngular.CoreAbstractions.Helpers.OutputPorts.Responses.Exceptions.AbstractsBases
{
    public abstract class BaseExceptionQueryResponseHelper
    {
        public abstract Task<QueryResponseDto<T>> AttributesValuesAsync<T>(string? messageErrorException, int? hResultException, string? sourceException);
    }
}
