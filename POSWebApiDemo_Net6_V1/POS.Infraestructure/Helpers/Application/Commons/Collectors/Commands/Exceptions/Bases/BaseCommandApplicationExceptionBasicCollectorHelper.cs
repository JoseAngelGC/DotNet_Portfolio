using POS.Infraestructure.SupportEntities.Commons.Collectors.Application;


namespace POS.Infraestructure.Helpers.Application.Commons.Collectors.Commands.Exceptions.Bases
{
    public abstract class BaseCommandApplicationExceptionBasicCollectorHelper
    {
        public abstract Task<CommandApplicationCollectorEntity> ResponseAsync(int? affectedRecords, int CustomerErrorCode, bool isSuccessFlag);
    }
}
