using StoreBasicCRUD.ApplicationCoreStructure.ApplicationEntities.Responses.Queries;


namespace StoreBasicCRUD.ApplicationCoreStructure.ApplicationHelpers.Collectors.ValidatorErrors.Queries.Bases
{
    public abstract class BaseApplicationCollectorQueryValidatorErrorHelper
    {
        public abstract Task<ApplicationServiceQueryResponseEntity<T>> ResponseAsync<T>(List<FluentValidation.Results.ValidationFailure> validationErrors);
    }
}
