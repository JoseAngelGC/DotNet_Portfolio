using StoreBasicCRUD.ApplicationCoreStructure.ApplicationEntities.Responses.Commands;


namespace StoreBasicCRUD.ApplicationCoreStructure.ApplicationHelpers.Collectors.Success.Commands.Bases
{
    public abstract class BaseApplicationCollectorCommandSuccessHelper
    {
        public abstract Task<ApplicationCollectorCommandResponseEntity> ResponseAsync(int? recordsAffected, string messageResponse);
    }
}
