using StoreBasicCRUD.ApplicationCoreStructure.ApplicationEntities.Responses.Commands;


namespace StoreBasicCRUD.ApplicationCoreStructure.ApplicationHelpers.Collectors.Exist.Commands.Bases
{
    public abstract class BaseApplicationCollectorCommandExistItemHelper
    {
        public abstract Task<ApplicationCollectorCommandResponseEntity> ResponseAsync();
    }
}
