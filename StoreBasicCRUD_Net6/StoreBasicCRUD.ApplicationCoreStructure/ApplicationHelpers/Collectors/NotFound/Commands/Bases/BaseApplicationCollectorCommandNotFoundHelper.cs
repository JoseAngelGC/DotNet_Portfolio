using StoreBasicCRUD.ApplicationCoreStructure.ApplicationEntities.Responses.Commands;


namespace StoreBasicCRUD.ApplicationCoreStructure.ApplicationHelpers.Collectors.NotFound.Commands.Bases
{
    public abstract class BaseApplicationCollectorCommandNotFoundHelper
    {
        public abstract Task<ApplicationCollectorCommandResponseEntity> ResponseAsync();
    }
}
