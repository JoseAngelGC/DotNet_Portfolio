using StoreBasicCRUD.ApplicationCoreStructure.ApplicationDtos.Shared.ServiceResponses.Queries;

namespace StoreBasicCRUD.ApplicationCoreStructure.ApplicationHelpers.Collectors.ValidatorErrors.Queries.Bases
{
    public abstract class BaseApplicationCollectorQueryValidatorErrorHelper
    {
        public abstract Task<ApplicationServiceQueryResponseDto<T>> ResponseAsync<T>(List<FluentValidation.Results.ValidationFailure> validationErrors);
    }
}
