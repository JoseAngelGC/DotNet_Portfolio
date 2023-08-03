using ApiCrudAndAngular.CoreAbstractions.CoreEntities.Dtos.OutputPortDtos.Responses;
using ApiCrudAndAngular.CoreAbstractions.Helpers.OutputPorts.Responses.Successful;
using ApiCrudAndAngular.CoreAbstractions.Helpers.OutputPorts.Responses.Successful.AbstractsBases;
using ApiCrudAndAngular.CoreServices.Helpers.OutputPorts.InternalResponses.Successful;

namespace ApiCrudAndAngular.CoreServices.Helpers.Services
{
    public class SuccessfulResponsesBasicHelpersService : ISuccessfulResponsesBasicHelpersService
    {
        private BaseSuccessfulCommandResponseHelper? _baseSuccessfulCommandResponseHelper;
        private BaseSuccessfulQueryResponseHelper? _baseSuccessfulQueryResponseHelper;

        public async Task<CommandResponseDto> CommandResponseHelperAsync(int? recordsAffected, string messageResponse)
        {
            _baseSuccessfulCommandResponseHelper = new SuccessfulCommandResponseBasicHelper();
            return await _baseSuccessfulCommandResponseHelper.AttributesValuesAsync(recordsAffected, messageResponse);
        }

        public async Task<QueryResponseDto<T>> QueryResponseHelperAsync<T>(T data)
        {
            _baseSuccessfulQueryResponseHelper = new SuccessfulQueryResponseBasicHelper();
            return await _baseSuccessfulQueryResponseHelper.AttributesValuesAsync(data);
        }
    }
}
