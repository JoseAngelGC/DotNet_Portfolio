using POS.Infraestructure.SupportEntities.Commons.Collectors.Interactors;


namespace POS.Infraestructure.Interfaces.Interactors.Commons.Collectors
{
    public interface ICommandInteractorBasicHelpers
    {
        public Task<CommandInteractorCollectorEntity> CommandInteractorExceptionBasicCollectorAsync(int? affectedRecords, bool executedCommandSuccesful, int CustomerErrorCode, int hResultException, string sourceException);
        public Task<CommandInteractorCollectorEntity> CommandInteractorSuccessfulBasicCollectorAsync(bool isSuccess, int? records, string controlEventMessage);
        public Task<CommandInteractorCollectorEntity> CommandInteractorExistItemBasicCollectorAsync(bool existItem);
    }
}
