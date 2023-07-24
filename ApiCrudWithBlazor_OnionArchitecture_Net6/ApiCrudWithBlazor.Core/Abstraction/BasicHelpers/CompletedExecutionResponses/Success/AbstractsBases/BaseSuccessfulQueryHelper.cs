using ApiCrudWithBlazor.CoreAbstractions.CoreEntities.Dtos.ResponsesDtos;



namespace ApiCrudWithBlazor.Core.Abstraction.BasicHelpers.CompletedExecutionResponses.Success.AbstractsBases
{
    public abstract class BaseSuccessfulQueryHelper
    {
        public abstract Task<QueryResponseDto<T>> AttributesValuesResponseAsync<T>(T data);
    }
}
