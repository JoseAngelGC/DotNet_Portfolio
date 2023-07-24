using ApiCrudWithBlazor.CoreAbstractions.CoreEntities.Dtos.ResponsesDtos;


namespace ApiCrudWithBlazor.Core.Abstraction.BasicHelpers.ExecutionFailsResponses.Errors.AbstractsBases
{
    public abstract class BaseCommandErrorsHelper
    {
        public abstract Task<CommandResponseDto> AttributesValuesResponseAsync();
    }
}
