using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using StoreBasicCRUD.ApplicationCoreStructure.ApplicationEntities.Responses.Commands;
using StoreBasicCRUD.ApplicationCoreStructure.ApplicationEntities.ValidatorErrors;
using StoreBasicCRUD.ApplicationCoreStructure.ApplicationHelpers.Collectors.ValidatorErrors.Commands.Bases;
using StoreBasicCRUD.Utilities.Shared.Consts;


namespace StoreBasicCRUD.ApplicationCoreStructure.ApplicationHelpers.Collectors.ValidatorErrors.Commands
{
    public class ApplicationBasicCollectorCommandValidatorErrorHelper : BaseApplicationCollectorCommandValidatorErrorHelper
    {
        public override async Task<ApplicationServiceCommandResponseEntity> ResponseAsync(List<ValidationFailure> validationErrors)
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

            ApplicationServiceCommandResponseEntity collectorResponseEntity = new()
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
