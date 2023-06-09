﻿using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using StoreBasicCRUD.ApplicationCoreStructure.ApplicationDtos.Shared.ServiceResponses.Queries;
using StoreBasicCRUD.ApplicationCoreStructure.ApplicationEntities.ValidatorErrors;
using StoreBasicCRUD.ApplicationCoreStructure.ApplicationHelpers.Collectors.ValidatorErrors.Queries.Bases;
using StoreBasicCRUD.Utilities.Shared.Consts;


namespace StoreBasicCRUD.ApplicationCoreStructure.ApplicationHelpers.Collectors.ValidatorErrors.Queries
{
    public class ApplicationBasicCollectorQueryValidatorErrorHelper : BaseApplicationCollectorQueryValidatorErrorHelper
    {
        public override async Task<ApplicationServiceQueryResponseDto<T>> ResponseAsync<T>(List<ValidationFailure> validationErrors)
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

            ApplicationServiceQueryResponseDto<T> collectorResponseEntity = new()
            {
                IsSuccess = false,
                MessageResponse = ReplyMessage.MESSAGE_VALIDATE,
                StatusResponse = StatusCodes.Status400BadRequest,
                ValidationErrors = validatorErrorsCustomList
            };

            return await Task.FromResult(collectorResponseEntity);
        }
    }
}
