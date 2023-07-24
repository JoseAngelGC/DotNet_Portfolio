using ApiCrudWithBlazor.Core.Abstraction.BasicHelpers.CustomResponses.ValidatorErrors.AbstractsBases;
using ApiCrudWithBlazor.CoreAbstractions.CoreEntities.Dtos.ResponsesDtos;
using ApiCrudWithBlazor.CoreAbstractions.CoreEntities.Utilities.Constants;
using ApiCrudWithBlazor.CoreAbstractions.CoreEntities.ValidatorErrors;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;

namespace ApiCrudWithBlazor.ApplicationServices.Helpers.Basics.ErrorResponses.Query
{
    public class CustomValidatorErrorsQueryBasicHelper : BaseCustomValidatorErrorsQueryHelper
    {
        public override async Task<QueryResponseDto<T>> AttributesValuesResponseAsync<T>(List<ValidationFailure> validationErrors)
        {
            List<ValidatorErrorsCustomEntity> validatorErrorsCustomList = new();
            foreach (var result in validationErrors)
            {
                ValidatorErrorsCustomEntity validatorErrorsCustomEntity = new()
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
