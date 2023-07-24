using ApiCrudWithBlazor.Core.Abstraction.BasicHelpers.CompletedExecutionResponses.Success;
using ApiCrudWithBlazor.Core.Abstraction.BasicHelpers.CustomResponses;
using ApiCrudWithBlazor.Core.Abstraction.BasicHelpers.ExecutionFailsResponses.Errors;
using ApiCrudWithBlazor.Core.Abstraction.BasicHelpers.ExecutionFailsResponses.Exceptions;
using ApiCrudWithBlazor.CoreAbstractions.CoreEntities.Dtos.ResponsesDtos;
using ApiCrudWithBlazor.CoreAbstractions.OutputPorts;
using FluentValidation.Results;

namespace ApiCrudWithBlazor.ApplicationServices.OutputPorstServices
{
    public class ResponsesOutputPortsBasicHelpersHub : IResponsesOutputPortsBasicHelpersHub
    {
        private readonly ISuccessfulResponseBasicsHelpersService _successfulResponseBasicsHelpersService;
        private readonly IErrorResponseBasicsHelpersService _errorResponseBasicsHelpersService;
        private readonly IExceptionResponseBasicsHelpersService _exceptionResponseBasicsHelpersService;
        private readonly ICustomErrorResponsesBasicsHelpersService _customErrorResponsesBasicsHelpersService;
        public ResponsesOutputPortsBasicHelpersHub(ISuccessfulResponseBasicsHelpersService successfulBasicResponseHelpers, IErrorResponseBasicsHelpersService errorResponseBasicsHelpersService, IExceptionResponseBasicsHelpersService exceptionResponseBasicsHelpersService, ICustomErrorResponsesBasicsHelpersService customErrorResponsesBasicsHelpersService)
        {
            _successfulResponseBasicsHelpersService = successfulBasicResponseHelpers;
            _errorResponseBasicsHelpersService = errorResponseBasicsHelpersService;
            _exceptionResponseBasicsHelpersService = exceptionResponseBasicsHelpersService;
            _customErrorResponsesBasicsHelpersService = customErrorResponsesBasicsHelpersService;
        }

        public async Task<CommandResponseDto> ExceptionCommandBasicHelperAsync(string? messageErrorException, int? hResultException, string? sourceException)
        {
            return await _exceptionResponseBasicsHelpersService.CommandExceptionHelperAsync(messageErrorException, hResultException,sourceException);
        }

        public async Task<QueryResponseDto<T>> ExceptionQueryBasicHelperAsync<T>(string? messageErrorException, int? hResultException, string? sourceException)
        {
            return await _exceptionResponseBasicsHelpersService.QueryExceptionHelperAsync<T>(messageErrorException, hResultException, sourceException);
        }

        public async Task<CommandResponseDto> NotFoundErrorCommandBasicHelperAsync()
        {
            return await _errorResponseBasicsHelpersService.CommandNotFoundErrorBasicHelperAsync();
        }

        public async Task<QueryResponseDto<T>> NotFoundErrorQueryBasicHelperAsync<T>()
        {
            return await _errorResponseBasicsHelpersService.QueryNotFoundErrorBasicHelperAsync<T>();
        }

        public async Task<CommandResponseDto> RecordExistErrorCommandBasicHelperAsync()
        {
            return await _errorResponseBasicsHelpersService.CommandExistingRecordErrorBasicHelperAsync();
        }

        public async Task<CommandResponseDto> ServerErrorCommandBasicHelperAsync()
        {
            return await _errorResponseBasicsHelpersService.CommandServerErrorBasicHelperAsync();
        }

        public async Task<QueryResponseDto<T>> ServerErrorQueryBasicHelperAsync<T>()
        {
            return await _errorResponseBasicsHelpersService.QueryServerErrorBasicHelperAsync<T>();
        }

        public async Task<CommandResponseDto> SuccessfulCommandBasicHelperAsync(int? recordsAffected, string messageResponse)
        {
            return await _successfulResponseBasicsHelpersService.SuccessfulCommandBasicHelperAsync(recordsAffected, messageResponse);
        }

        public async Task<QueryResponseDto<T>> SuccessfulQueryBasicHelperAsync<T>(T data)
        {
            return await _successfulResponseBasicsHelpersService.SuccessfulQueryBasicHelperAsync(data);
        }

        public async Task<CommandResponseDto> ValidatorErrorsCommandBasicHelperAsync(List<ValidationFailure> validationErrors)
        {
            return await _customErrorResponsesBasicsHelpersService.ValidatorErrorsCommandBasicHelperAsync(validationErrors);
        }

        public async Task<QueryResponseDto<T>> ValidatorErrorsQueryBasicHelperAsync<T>(List<ValidationFailure> validationErrors)
        {
            return await _customErrorResponsesBasicsHelpersService.ValidatorErrorsQueryBasicHelperAsync<T>(validationErrors);
        }
    }
}
