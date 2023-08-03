using ApiCrudAndAngular.CoreAbstractions.CoreEntities.Dtos.OutputPortDtos.Responses;
using ApiCrudAndAngular.CoreAbstractions.Helpers.OutputPorts.Responses.Exceptions;
using ApiCrudAndAngular.CoreAbstractions.Helpers.OutputPorts.Responses.Exceptions.AbstractsBases;
using ApiCrudAndAngular.CoreServices.Helpers.OutputPorts.InternalResponses.Exceptions;

namespace ApiCrudAndAngular.CoreServices.Helpers.Services
{
    public class ExceptionResponsesBasicHelpersService : IExceptionResponsesBasicHelpersService
    {
        private BaseExceptionCommandResponseHelper? _baseExceptionCommandResponseHelper;
        private BaseExceptionQueryResponseHelper? _baseExceptionQueryResponseHelper;

        public Task<CommandResponseDto> CommandResponseHelperAsync(string? messageErrorException, int? hResultException, string? sourceException)
        {
            _baseExceptionCommandResponseHelper = new ExceptionCommandResponseBasicHelper();
            return _baseExceptionCommandResponseHelper.AttributesValuesAsync(messageErrorException, hResultException,sourceException);
        }

        public Task<QueryResponseDto<T>> QueryResponseHelperAsync<T>(string? messageErrorException, int? hResultException, string? sourceException)
        {
            _baseExceptionQueryResponseHelper = new ExceptionQueryResponseBasicHelper();
            return _baseExceptionQueryResponseHelper.AttributesValuesAsync<T>(messageErrorException, hResultException, sourceException);
        }
    }
}
