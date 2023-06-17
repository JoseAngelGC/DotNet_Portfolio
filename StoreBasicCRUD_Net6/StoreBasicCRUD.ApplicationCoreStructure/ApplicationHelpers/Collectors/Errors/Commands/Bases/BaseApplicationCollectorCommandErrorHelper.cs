using StoreBasicCRUD.ApplicationCoreStructure.ApplicationEntities.Responses.Commands;


namespace StoreBasicCRUD.ApplicationCoreStructure.ApplicationHelpers.Collectors.Errors.Commands.Bases
{
    public abstract class BaseApplicationCollectorCommandErrorHelper
    {
        public abstract Task<ApplicationCollectorCommandResponseEntity> ResponseAsync();
    }
}
