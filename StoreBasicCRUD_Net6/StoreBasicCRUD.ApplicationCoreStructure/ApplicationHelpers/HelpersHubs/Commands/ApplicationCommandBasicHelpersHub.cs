using FluentValidation.Results;
using StoreBasicCRUD.ApplicationCoreStructure.ApplicationEntities.Responses.Commands;
using StoreBasicCRUD.ApplicationCoreStructure.ApplicationHelpers.Collectors.Errors.Commands;
using StoreBasicCRUD.ApplicationCoreStructure.ApplicationHelpers.Collectors.Exceptions.Commands;
using StoreBasicCRUD.ApplicationCoreStructure.ApplicationHelpers.Collectors.Exist.Commands;
using StoreBasicCRUD.ApplicationCoreStructure.ApplicationHelpers.Collectors.Fails.Commands;
using StoreBasicCRUD.ApplicationCoreStructure.ApplicationHelpers.Collectors.NotFound.Commands;
using StoreBasicCRUD.ApplicationCoreStructure.ApplicationHelpers.Collectors.Success.Commands;
using StoreBasicCRUD.ApplicationCoreStructure.ApplicationHelpers.Collectors.ValidatorErrors.Commands;
using StoreBasicCRUD.ApplicationCoreStructure.ApplicationHelpers.HelpersHubs.Commands.Interfaces;
using StoreBasicCRUD.ApplicationCoreStructure.ApplicationHelpers.ServicesResponses.Commands;

namespace StoreBasicCRUD.ApplicationCoreStructure.ApplicationHelpers.HelpersHubs.Commands
{
    public class ApplicationCommandBasicHelpersHub : IApplicationCommandHelpersHub
    {
        public async Task<ApplicationCollectorCommandResponseEntity> BasicCollectorCommandErrorAsync()
        {
            ApplicationBasicCollectorCommandErrorHelper basicCollectorCommandErrorHelper = new ();
            return await basicCollectorCommandErrorHelper.ResponseAsync();
        }

        public async Task<ApplicationCollectorCommandResponseEntity> BasicCollectorCommandExceptionAsync(string? messageErrorException, int? hResultException, string? sourceException)
        {
            ApplicationBasicCollectorCommandExceptionHelper basicCollectorCommandExceptionHelper = new();
            return await basicCollectorCommandExceptionHelper.ResponseAsync(messageErrorException, hResultException, sourceException);
        }

        public async Task<ApplicationCollectorCommandResponseEntity> BasicCollectorCommandExecutionErrorsAsync(int? existRegister)
        {
            ApplicationBasicCollectorCommandExecutionFailedHelper basicCollectorCommandExecutionFailedHelper = new();
            return await basicCollectorCommandExecutionFailedHelper.ResponseAsync(existRegister);
        }

        public async Task<ApplicationCollectorCommandResponseEntity> BasicCollectorCommandExistItemAsync()
        {
            ApplicationBasicCollectorCommandExistItemHelper basicCollectorCommandExistItemHelper = new();
            return await basicCollectorCommandExistItemHelper.ResponseAsync();
        }

        public async Task<ApplicationCollectorCommandResponseEntity> BasicCollectorCommandExistUniqueDataAsync(int? existUniqueData)
        {
            ApplicationBasicCollectorCommandExistItemFailedHelper basicCollectorCommandExistItemFailedHelper = new();
            return await basicCollectorCommandExistItemFailedHelper.ResponseAsync(existUniqueData);
        }

        public async Task<ApplicationCollectorCommandResponseEntity> BasicCollectorCommandNotExistAsync()
        {
            ApplicationBasicCollectorCommandNotFoundHelper basicCollectorCommandNotFoundHelper = new();
            return await basicCollectorCommandNotFoundHelper.ResponseAsync();
        }

        public async Task<ApplicationCollectorCommandResponseEntity> BasicCollectorCommandSuccessfulAsync(int? recordsAffected, string messageResponse)
        {
            ApplicationBasicCollectorCommandSuccessHelper basicCollectorCommandSuccessHelper = new();
            return await basicCollectorCommandSuccessHelper.ResponseAsync(recordsAffected, messageResponse);
        }

        public async Task<ApplicationServiceCommandResponseEntity> BasicCollectorCommandValidatorErrorsAsync(List<ValidationFailure> validationErrors)
        {
            ApplicationBasicCollectorCommandValidatorErrorHelper basicCollectorCommandValidatorErrorHelper = new();
            return await basicCollectorCommandValidatorErrorHelper.ResponseAsync(validationErrors);
        }

        public async Task<ApplicationServiceCommandResponseEntity> CommandServiceResponseAsync(ApplicationCollectorCommandResponseEntity collectorEntityResponse)
        {
            ApplicationServiceCommandResponseHelper serviceCommandResponseHelper = new();
            return await serviceCommandResponseHelper.ResponseAsync(collectorEntityResponse);
        }
    }
}
