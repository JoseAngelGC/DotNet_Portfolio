using ApiCrudAndAngular.CoreAbstractions.CoreEntities.Dtos.OutputPortDtos.Responses;

namespace ApiCrudAndAngular.CoreAbstractions.Helpers.OutputPorts.Responses.Errors.AbstractsBases
{
    public abstract class BaseErrorQueryResponseHelper
    {
        public abstract Task<QueryResponseDto<T>> AttributesValuesAsync<T>();
    }
}
