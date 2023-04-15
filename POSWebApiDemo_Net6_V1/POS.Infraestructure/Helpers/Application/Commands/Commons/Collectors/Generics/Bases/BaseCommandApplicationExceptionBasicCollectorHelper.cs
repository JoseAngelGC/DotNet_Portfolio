using POS.Infraestructure.SupportEntities.Commons.Collectors.Application;


namespace POS.Infraestructure.Helpers.Application.Commands.Commons.Collectors.Generics.Bases
{
    public abstract class BaseCommandApplicationExceptionBasicCollectorHelper
    {
        public abstract Task<CommandApplicationCollectorEntity> ResponseAsync(int? affectedRecords, int CustomerErrorCode, bool isSuccessFlag);
    }
}
