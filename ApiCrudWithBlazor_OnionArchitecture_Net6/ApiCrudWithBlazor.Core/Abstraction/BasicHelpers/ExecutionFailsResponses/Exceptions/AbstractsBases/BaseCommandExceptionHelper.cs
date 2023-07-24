using ApiCrudWithBlazor.CoreAbstractions.CoreEntities.Dtos.ResponsesDtos;


namespace ApiCrudWithBlazor.Core.Abstraction.BasicHelpers.ExecutionFailsResponses.Exceptions.AbstractsBases
{
    public abstract class BaseCommandExceptionHelper
    {
        public abstract Task<CommandResponseDto> AttributesValuesResponseAsync(string? messageErrorException, int? hResultException, string? sourceException);
    }
}
