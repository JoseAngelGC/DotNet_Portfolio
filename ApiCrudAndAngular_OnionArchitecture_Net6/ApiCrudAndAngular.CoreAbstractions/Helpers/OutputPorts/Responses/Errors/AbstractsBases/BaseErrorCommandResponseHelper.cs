using ApiCrudAndAngular.CoreAbstractions.CoreEntities.Dtos.OutputPortDtos.Responses;

namespace ApiCrudAndAngular.CoreAbstractions.Helpers.OutputPorts.Responses.Errors.AbstractsBases
{
    public abstract class BaseErrorCommandResponseHelper
    {
        public abstract Task<CommandResponseDto> AttributesValuesAsync();
    }
}
