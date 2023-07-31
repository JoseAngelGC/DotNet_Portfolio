using ApiCrudAndAngular.CoreAbstractions.CoreEntities.Dtos.OutputPortDtos.Responses;

namespace ApiCrudAndAngular.CoreAbstractions.Helpers.OutputPorts.Responses.Successful.AbstractsBases
{
    public abstract class BaseSuccessfulCommandResponseHelper
    {
        public abstract Task<CommandResponseDto> AttributesValuesResponseAsync(int? recordsAffected, string messageResponse);
    }
}
