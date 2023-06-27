using StoreBasicCRUD.ApplicationCoreStructure.ApplicationDtos.Shared.ServiceResponses.Commands;

namespace StoreBasicCRUD.ApplicationCoreStructure.ApplicationHelpers.Collectors.ValidatorErrors.Commands.Bases
{
    public abstract class BaseApplicationCollectorCommandValidatorErrorHelper
    {
        public abstract Task<ApplicationServiceCommandResponseDto> ResponseAsync(List<FluentValidation.Results.ValidationFailure> validationErrors);
    }
}
