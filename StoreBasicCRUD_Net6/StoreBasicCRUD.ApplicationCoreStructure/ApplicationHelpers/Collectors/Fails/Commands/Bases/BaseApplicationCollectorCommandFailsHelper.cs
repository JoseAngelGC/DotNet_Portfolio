using StoreBasicCRUD.ApplicationCoreStructure.ApplicationEntities.Responses.Commands;


namespace StoreBasicCRUD.ApplicationCoreStructure.ApplicationHelpers.Collectors.Fails.Commands.Bases
{
    public abstract class BaseApplicationCollectorCommandFailsHelper
    {
        public abstract Task<ApplicationCollectorCommandResponseEntity> ResponseAsync(int? existRegister);
    }
}
