using ApiCrudWithBlazor.CoreAbstractions.CoreEntities.Dtos.ResponsesDtos;


namespace ApiCrudWithBlazor.Core.Abstraction.BasicHelpers.CompletedExecutionResponses.Success.AbstractsBases
{
    public abstract class BaseSuccessfulCommandHelper
    {
        public abstract Task<CommandResponseDto> AttributesValuesResponseAsync(int? recordsAffected, string messageResponse);
    }
}
