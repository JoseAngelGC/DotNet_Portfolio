using StoreBasicCRUD.ApplicationCoreStructure.ApplicationEntities.Responses.Commands;


namespace StoreBasicCRUD.ApplicationCoreStructure.ApplicationHelpers.Collectors.ValidatorErrors.Commands.Bases
{
    public abstract class BaseApplicationCollectorCommandValidatorErrorHelper
    {
        public abstract Task<ApplicationServiceCommandResponseEntity> ResponseAsync(List<FluentValidation.Results.ValidationFailure> validationErrors);
    }
}
