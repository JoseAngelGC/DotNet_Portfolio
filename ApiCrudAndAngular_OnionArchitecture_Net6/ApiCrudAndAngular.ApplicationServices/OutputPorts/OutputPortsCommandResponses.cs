using ApiCrudAndAngular.CoreAbstractions.CoreEntities.Dtos.OutputPortDtos.Responses;
using ApiCrudAndAngular.CoreAbstractions.Helpers.OutputPorts.Responses.CustomsValidatorErrors;
using ApiCrudAndAngular.CoreAbstractions.Helpers.OutputPorts.Responses.Errors;
using ApiCrudAndAngular.CoreAbstractions.Helpers.OutputPorts.Responses.Exceptions;
using ApiCrudAndAngular.CoreAbstractions.Helpers.OutputPorts.Responses.Successful;
using ApiCrudAndAngular.CoreAbstractions.OutputPorts.Responses;
using FluentValidation.Results;

namespace ApiCrudAndAngular.ApplicationServices.OutputPorts
{
    public class OutputPortsCommandResponses : IOutputPortsCommandResponses
    {
        private readonly ISuccessfulResponsesBasicHelpersService _successfulResponsesBasicHelpersService;
        private readonly IErrorResponsesBasicHelpersService _errorResponsesBasicHelpersService;
        private readonly IExceptionResponsesBasicHelpersService _exceptionResponsesBasicHelpersService;
        private readonly ICustomValidatorErrorsBasicHelpersService _customValidatorErrorsBasicHelpersService;
        public OutputPortsCommandResponses(ISuccessfulResponsesBasicHelpersService successfulResponsesBasicHelpersService, IErrorResponsesBasicHelpersService errorResponsesBasicHelpersService, IExceptionResponsesBasicHelpersService exceptionResponsesBasicHelpersService, ICustomValidatorErrorsBasicHelpersService customValidatorErrorsBasicHelpersService)
        {
            _successfulResponsesBasicHelpersService = successfulResponsesBasicHelpersService;
            _errorResponsesBasicHelpersService = errorResponsesBasicHelpersService;
            _exceptionResponsesBasicHelpersService = exceptionResponsesBasicHelpersService;
            _customValidatorErrorsBasicHelpersService = customValidatorErrorsBasicHelpersService;
        }

        public async Task<CommandResponseDto> CustomValidatorErrorsResponseHelperAsync(List<ValidationFailure> validationErrors)
        {
            return await _customValidatorErrorsBasicHelpersService.CommandResponseHelperAsync(validationErrors);
        }

        public async Task<CommandResponseDto> ExceptionResponseHelperAsync(string? messageErrorException, int? hResultException, string? sourceException)
        {
            return await _exceptionResponsesBasicHelpersService.CommandResponseHelperAsync(messageErrorException, hResultException, sourceException);
        }

        public async Task<CommandResponseDto> ExistingRecordErrorResponseHelperAsync()
        {
            return await _errorResponsesBasicHelpersService.ExistingRecordErrorCommandResponseHelperAsync();
        }

        public async Task<CommandResponseDto> NotFoundDataErrorResponseHelperAsync()
        {
            return await _errorResponsesBasicHelpersService.NotFoundDataErrorCommandResponseHelperAsync();
        }

        public async Task<CommandResponseDto> ServerErrorResponseHelperAsync()
        {
            return await _errorResponsesBasicHelpersService.ServerErrorCommandResponseHelperAsync();
        }

        public async Task<CommandResponseDto> SuccessfulResponseHelperAsync(int? recordsAffected, string messageResponse)
        {
            return await _successfulResponsesBasicHelpersService.CommandResponseHelperAsync(recordsAffected, messageResponse);
        }
    }
}
