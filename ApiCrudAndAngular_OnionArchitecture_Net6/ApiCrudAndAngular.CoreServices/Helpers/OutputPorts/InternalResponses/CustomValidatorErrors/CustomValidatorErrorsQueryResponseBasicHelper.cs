using ApiCrudAndAngular.CoreAbstractions.CoreEntities.Dtos.OutputPortDtos.Responses;
using ApiCrudAndAngular.CoreAbstractions.CoreEntities.Utilities.Constants;
using ApiCrudAndAngular.CoreAbstractions.CoreEntities.ValidatorErrors;
using ApiCrudAndAngular.CoreAbstractions.Helpers.OutputPorts.Responses.CustomsValidatorErrors.AbstractsBases;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;

namespace ApiCrudAndAngular.CoreServices.Helpers.OutputPorts.InternalResponses.CustomValidatorErrors
{
    internal class CustomValidatorErrorsQueryResponseBasicHelper : BaseValidatorErrorsQueryResponseHelper
    {
        public override async Task<QueryResponseDto<T>> AttributesValuesAsync<T>(List<ValidationFailure> validationErrors)
        {
            List<CustomValidatorErrorsEntity> validatorErrorsCustomList = new();
            foreach (var result in validationErrors)
            {
                CustomValidatorErrorsEntity validatorErrorsCustomEntity = new()
                {
                    PropertyName = result.PropertyName,
                    ErrorMessage = result.ErrorMessage
                };
                validatorErrorsCustomList.Add(validatorErrorsCustomEntity);
            }

            QueryResponseDto<T> collectorResponseEntity = new()
            {
                IsSuccess = false,
                MessageResponse = ReplyMessageConstants.MESSAGE_VALIDATE,
                StatusResponse = StatusCodes.Status400BadRequest,
                ValidationErrors = validatorErrorsCustomList
            };

            return await Task.FromResult(collectorResponseEntity);
        }
    }
}
