using ApiCrudWithBlazor.CoreAbstractions.CoreEntities.Dtos.ResponsesDtos;


namespace ApiCrudWithBlazor.Core.Abstraction.BasicHelpers.ExecutionFailsResponses.Errors.AbstractsBases
{
    public abstract class BaseQueryErrorsHelper
    {
        public abstract Task<QueryResponseDto<T>> AttributesValuesResponseAsync<T>();
    }
}
