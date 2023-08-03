using ApiCrudAndAngular.CoreAbstractions.CoreEntities.Dtos.OutputPortDtos.Responses;
using ApiCrudAndAngular.CoreAbstractions.Helpers.OutputPorts.Responses.CustomsValidatorErrors;
using ApiCrudAndAngular.CoreAbstractions.Helpers.OutputPorts.Responses.CustomsValidatorErrors.AbstractsBases;
using ApiCrudAndAngular.CoreServices.Helpers.OutputPorts.InternalResponses.CustomValidatorErrors;
using FluentValidation.Results;

namespace ApiCrudAndAngular.CoreServices.Helpers.Services
{
    public class CustomValidatorErrorsBasicHelpersService : ICustomValidatorErrorsBasicHelpersService
    {
        private BaseValidatorErrorsCommandResponseHelper? _baseValidatorErrorsCommandResponse;
        private BaseValidatorErrorsQueryResponseHelper? _baseValidatorErrorsQueryResponse;
        public async Task<QueryResponseDto<T>> QueryResponseHelperAsync<T>(List<ValidationFailure> validationErrors)
        {
            _baseValidatorErrorsQueryResponse = new CustomValidatorErrorsQueryResponseBasicHelper();
            return await _baseValidatorErrorsQueryResponse.AttributesValuesAsync<T>(validationErrors);
        }

        public async Task<CommandResponseDto> CommandResponseHelperAsync(List<ValidationFailure> validationErrors)
        {
            _baseValidatorErrorsCommandResponse = new CustomValidatorErrorsCommandResponseBasicHelper();
            return await _baseValidatorErrorsCommandResponse.AttributesValuesAsync(validationErrors);
        }
    }
}
