using ApiCrudAndAngular.CoreAbstractions.CoreEntities.Dtos.OutputPortDtos.Responses;

namespace ApiCrudAndAngular.CoreAbstractions.Helpers.OutputPorts.Responses.Exceptions.AbstractsBases
{
    public abstract class BaseExceptionCommandResponseHelper
    {
        public abstract Task<CommandResponseDto> AttributesValuesAsync(string? messageErrorException, int? hResultException, string? sourceException);
    }
}
