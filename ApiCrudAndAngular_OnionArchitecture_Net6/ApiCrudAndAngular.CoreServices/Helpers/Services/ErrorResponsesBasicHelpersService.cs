using ApiCrudAndAngular.CoreAbstractions.CoreEntities.Dtos.OutputPortDtos.Responses;
using ApiCrudAndAngular.CoreAbstractions.Helpers.OutputPorts.Responses.Errors;
using ApiCrudAndAngular.CoreAbstractions.Helpers.OutputPorts.Responses.Errors.AbstractsBases;
using ApiCrudAndAngular.CoreServices.Helpers.OutputPorts.InternalResponses.Errors.Commands;
using ApiCrudAndAngular.CoreServices.Helpers.OutputPorts.InternalResponses.Errors.Queries;

namespace ApiCrudAndAngular.CoreServices.Helpers.Services
{
    public class ErrorResponsesBasicHelpersService : IErrorResponsesBasicHelpersService
    {
        private BaseErrorCommandResponseHelper? _baseErrorCommandResponseHelper;
        private BaseErrorQueryResponseHelper? _baseErrorQueryResponseHelper;

        public async Task<CommandResponseDto> ExistingRecordErrorCommandResponseHelperAsync()
        {
            _baseErrorCommandResponseHelper = new ExistingRecordErrorCommandResponseBasicHelper();
            return await _baseErrorCommandResponseHelper.AttributesValuesAsync();
        }

        public async Task<CommandResponseDto> NotFoundDataErrorCommandResponseHelperAsync()
        {
            _baseErrorCommandResponseHelper = new NotFoundErrorCommandResponseBasicHelper();
            return await _baseErrorCommandResponseHelper.AttributesValuesAsync();
        }

        public Task<CommandResponseDto> ServerErrorCommandResponseHelperAsync()
        {
            _baseErrorCommandResponseHelper = new ServerErrorCommandResponseBasicHelper();
            return _baseErrorCommandResponseHelper.AttributesValuesAsync();
        }

        public async Task<QueryResponseDto<T>> NotFoundDataErrorQueryResponseHelperAsync<T>()
        {
            _baseErrorQueryResponseHelper = new NotFoundErrorQueryResponseBasicHelper();
            return await _baseErrorQueryResponseHelper.AttributesValuesAsync<T>();
        }

        public async Task<QueryResponseDto<T>> ServerErrorQueryResponseHelperAsync<T>()
        {
            _baseErrorQueryResponseHelper = new ServerErrorQueryResponseBasicHelper();
            return await _baseErrorQueryResponseHelper.AttributesValuesAsync<T>();
        }
    }
}
