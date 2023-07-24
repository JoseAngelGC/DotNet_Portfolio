using ApiCrudWithBlazor.ApplicationServices.Helpers.Basics.ErrorResponses.Command;
using ApiCrudWithBlazor.ApplicationServices.Helpers.Basics.ErrorResponses.Query;
using ApiCrudWithBlazor.Core.Abstraction.BasicHelpers.ExecutionFailsResponses.Errors;
using ApiCrudWithBlazor.Core.Abstraction.BasicHelpers.ExecutionFailsResponses.Errors.AbstractsBases;
using ApiCrudWithBlazor.CoreAbstractions.CoreEntities.Dtos.ResponsesDtos;


namespace ApiCrudWithBlazor.ApplicationServices.Helpers.Services
{
    public class ErrorResponseBasicsHelpersService : IErrorResponseBasicsHelpersService
    {
        private BaseQueryErrorsHelper? _baseQueryErrorsHelper;
        private BaseCommandErrorsHelper? _baseCommandErrorsHelper;

        public Task<CommandResponseDto> CommandExistingRecordErrorBasicHelperAsync()
        {
            _baseCommandErrorsHelper = new CommandExistingRecordErrorBasicHelper();
            return _baseCommandErrorsHelper.AttributesValuesResponseAsync();
        }

        public Task<CommandResponseDto> CommandNotFoundErrorBasicHelperAsync()
        {
            _baseCommandErrorsHelper = new CommandNotFoundErrorBasicHelper();
            return _baseCommandErrorsHelper.AttributesValuesResponseAsync();
        }

        public Task<CommandResponseDto> CommandServerErrorBasicHelperAsync()
        {
            _baseCommandErrorsHelper = new CommandServerErrorBasicHelper();
            return _baseCommandErrorsHelper.AttributesValuesResponseAsync();
        }

        public Task<QueryResponseDto<T>> QueryNotFoundErrorBasicHelperAsync<T>()
        {
            _baseQueryErrorsHelper = new QueryNotFoundErrorBasicHelper();
            return _baseQueryErrorsHelper.AttributesValuesResponseAsync<T>();
        }

        public Task<QueryResponseDto<T>> QueryServerErrorBasicHelperAsync<T>()
        {
            _baseQueryErrorsHelper = new QueryServerErrorBasicHelper();
            return _baseQueryErrorsHelper.AttributesValuesResponseAsync<T>();
        }
    }
}
