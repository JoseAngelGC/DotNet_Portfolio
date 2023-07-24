using ApiCrudWithBlazor.CoreAbstractions.CoreEntities.Dtos.ResponsesDtos;


namespace ApiCrudWithBlazor.Core.Abstraction.BasicHelpers.ExecutionFailsResponses.Exceptions.AbstractsBases
{
    public abstract class BaseQueryExceptionHelper
    {
        public abstract Task<QueryResponseDto<T>> AttributesValuesResponseAsync<T>(string? messageErrorException, int? hResultException, string? sourceException);
    }
}
