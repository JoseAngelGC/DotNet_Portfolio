using StoreBasicCRUD.ApplicationCoreStructure.ApplicationEntities.Responses.Commands;


namespace StoreBasicCRUD.ApplicationCoreStructure.ApplicationHelpers.ServicesResponses.Commands.Bases
{
    public abstract class BaseApplicationServiceCommandResponseHelper
    {
        public abstract Task<ApplicationServiceCommandResponseEntity> ResponseAsync(ApplicationCollectorCommandResponseEntity collectorEntityResponse);
    }
}
