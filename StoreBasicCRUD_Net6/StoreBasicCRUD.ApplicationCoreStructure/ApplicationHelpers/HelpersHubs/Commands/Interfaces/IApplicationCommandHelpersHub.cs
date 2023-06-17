using StoreBasicCRUD.ApplicationCoreStructure.ApplicationEntities.Responses.Commands;


namespace StoreBasicCRUD.ApplicationCoreStructure.ApplicationHelpers.HelpersHubs.Commands.Interfaces
{
    public interface IApplicationCommandHelpersHub
    {
        Task<ApplicationCollectorCommandResponseEntity> BasicCollectorCommandSuccessfulAsync(int? recordsAffected, string messageResponse);
        Task<ApplicationCollectorCommandResponseEntity> BasicCollectorCommandExceptionAsync(string? messageErrorException, int? hResultException, string? sourceException);
        Task<ApplicationCollectorCommandResponseEntity> BasicCollectorCommandExistItemAsync();
        Task<ApplicationCollectorCommandResponseEntity> BasicCollectorCommandErrorAsync();
        Task<ApplicationCollectorCommandResponseEntity> BasicCollectorCommandExistUniqueDataAsync(int? existUniqueData);
        Task<ApplicationCollectorCommandResponseEntity> BasicCollectorCommandExecutionErrorsAsync(int? existRegister);
        Task<ApplicationCollectorCommandResponseEntity> BasicCollectorCommandNotExistAsync();
        Task<ApplicationServiceCommandResponseEntity> CommandServiceResponseAsync(ApplicationCollectorCommandResponseEntity collectorEntityResponse);
        Task<ApplicationServiceCommandResponseEntity> BasicCollectorCommandValidatorErrorsAsync(List<FluentValidation.Results.ValidationFailure> validationErrors);
    }
}
