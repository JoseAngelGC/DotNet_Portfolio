using ApiCrudAndAngular.CoreAbstractions.CoreEntities.Dtos.OutputPortDtos.Responses;

namespace ApiCrudAndAngular.CoreAbstractions.Helpers.OutputPorts.Responses.Successful.AbstractsBases
{
    public abstract class BaseSuccessfulQueryResponseHelper
    {
        public abstract Task<QueryResponseDto<T>> AttributesValuesAsync<T>(T data);
    }
}
