using ApiCrudAndAngular.CoreAbstractions.CoreEntities.Dtos.OutputPortDtos.Responses;
using ApiCrudAndAngular.CoreAbstractions.Helpers.OutputPorts.Responses.CustomsValidatorErrors;
using ApiCrudAndAngular.CoreAbstractions.Helpers.OutputPorts.Responses.Errors;
using ApiCrudAndAngular.CoreAbstractions.Helpers.OutputPorts.Responses.Exceptions;
using ApiCrudAndAngular.CoreAbstractions.Helpers.OutputPorts.Responses.Successful;
using ApiCrudAndAngular.CoreAbstractions.OutputPorts.Responses;
using FluentValidation.Results;

namespace ApiCrudAndAngular.ApplicationServices.OutputPorts
{
    public class OutputPortsQueryResponses : IOutputPortsQueryResponses
    {
        private readonly ISuccessfulResponsesBasicHelpersService _successfulResponsesBasicHelpersService;
        private readonly IErrorResponsesBasicHelpersService _errorResponsesBasicHelpersService;
        private readonly IExceptionResponsesBasicHelpersService _exceptionResponsesBasicHelpersService;
        private readonly ICustomValidatorErrorsBasicHelpersService _customValidatorErrorsBasicHelpersService;
        public OutputPortsQueryResponses(ISuccessfulResponsesBasicHelpersService successfulResponsesBasicHelpersService, IErrorResponsesBasicHelpersService errorResponsesBasicHelpersService, IExceptionResponsesBasicHelpersService exceptionResponsesBasicHelpersService, ICustomValidatorErrorsBasicHelpersService customValidatorErrorsBasicHelpersService)
        {
            _successfulResponsesBasicHelpersService = successfulResponsesBasicHelpersService;
            _errorResponsesBasicHelpersService = errorResponsesBasicHelpersService;
            _exceptionResponsesBasicHelpersService = exceptionResponsesBasicHelpersService;
            _customValidatorErrorsBasicHelpersService = customValidatorErrorsBasicHelpersService;
        }

        public async Task<QueryResponseDto<T>> CustomValidatorErrorsResponseHelperAsync<T>(List<ValidationFailure> validationErrors)
        {
            return await _customValidatorErrorsBasicHelpersService.QueryResponseHelperAsync<T>(validationErrors);
        }

        public async Task<QueryResponseDto<T>> ExceptionResponseHelperAsync<T>(string? messageErrorException, int? hResultException, string? sourceException)
        {
            return await _exceptionResponsesBasicHelpersService.QueryResponseHelperAsync<T>(messageErrorException, hResultException, sourceException);
        }

        public async Task<QueryResponseDto<T>> NotFoundDataErrorResponseHelperAsync<T>()
        {
            return await _errorResponsesBasicHelpersService.NotFoundDataErrorQueryResponseHelperAsync<T>();
        }

        public async Task<QueryResponseDto<T>> ServerErrorResponseHelperAsync<T>()
        {
            return await _errorResponsesBasicHelpersService.ServerErrorQueryResponseHelperAsync<T>();
        }

        public async Task<QueryResponseDto<T>> SuccessfulResponseHelperAsync<T>(T data)
        {
            return await _successfulResponsesBasicHelpersService.QueryResponseHelperAsync(data);
        }
    }
}
