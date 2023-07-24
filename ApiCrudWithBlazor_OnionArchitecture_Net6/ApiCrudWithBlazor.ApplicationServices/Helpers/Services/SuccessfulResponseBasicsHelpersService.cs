using ApiCrudWithBlazor.ApplicationServices.Helpers.Basics.SuccessfulResponses.Command;
using ApiCrudWithBlazor.ApplicationServices.Helpers.Basics.SuccessfulResponses.Query;
using ApiCrudWithBlazor.Core.Abstraction.BasicHelpers.CompletedExecutionResponses.Success;
using ApiCrudWithBlazor.Core.Abstraction.BasicHelpers.CompletedExecutionResponses.Success.AbstractsBases;
using ApiCrudWithBlazor.CoreAbstractions.CoreEntities.Dtos.ResponsesDtos;


namespace ApiCrudWithBlazor.ApplicationServices.Helpers.Services
{
    public class SuccessfulResponseBasicsHelpersService : ISuccessfulResponseBasicsHelpersService
    {
        private BaseSuccessfulQueryHelper? _successfulQueryHelper;
        private BaseSuccessfulCommandHelper? _successfulCommandHelper;

        public async Task<CommandResponseDto> SuccessfulCommandBasicHelperAsync(int? recordsAffected, string messageResponse)
        {
            _successfulCommandHelper = new SuccessfulCommandBasicHelper();
            return await _successfulCommandHelper.AttributesValuesResponseAsync(recordsAffected, messageResponse);
        }

        public async Task<QueryResponseDto<T>> SuccessfulQueryBasicHelperAsync<T>(T data)
        {
            _successfulQueryHelper = new SuccessfulQueryBasicHelper();
            return await _successfulQueryHelper.AttributesValuesResponseAsync(data);
        }
    }
}
