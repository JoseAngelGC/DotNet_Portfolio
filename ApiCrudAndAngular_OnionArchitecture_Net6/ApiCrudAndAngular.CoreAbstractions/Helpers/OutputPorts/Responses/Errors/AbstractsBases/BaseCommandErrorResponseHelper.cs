using ApiCrudAndAngular.CoreAbstractions.CoreEntities.Dtos.OutputPortDtos.Responses;

namespace ApiCrudAndAngular.CoreAbstractions.Helpers.OutputPorts.Responses.Errors.AbstractsBases
{
    public abstract class BaseCommandErrorResponseHelper
    {
        public abstract Task<CommandResponseDto> AttributesValuesAsync();
    }
}
