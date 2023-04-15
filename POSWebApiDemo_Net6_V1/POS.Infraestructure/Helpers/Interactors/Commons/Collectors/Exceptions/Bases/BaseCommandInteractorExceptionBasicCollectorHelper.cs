using POS.Infraestructure.SupportEntities.Commons.Collectors.Interactors;


namespace POS.Infraestructure.Helpers.Interactors.Commons.Collectors.Exceptions.Bases
{
    public abstract class BaseCommandInteractorExceptionBasicCollectorHelper
    {
        public abstract Task<CommandInteractorCollectorEntity> ResponseAsync(int? affectedRecords, bool executedCommandSuccesful, int CustomerErrorCode, int hResultException, string sourceException);
    }
}
