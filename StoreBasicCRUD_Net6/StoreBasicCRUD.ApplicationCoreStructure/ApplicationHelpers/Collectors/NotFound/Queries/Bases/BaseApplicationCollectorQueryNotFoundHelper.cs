using StoreBasicCRUD.ApplicationCoreStructure.ApplicationEntities.Responses.Queries;


namespace StoreBasicCRUD.ApplicationCoreStructure.ApplicationHelpers.Collectors.NotFound.Queries.Bases
{
    public abstract class BaseApplicationCollectorQueryNotFoundHelper
    {
        public abstract Task<ApplicationCollectorQueryResponseEntity<T>> ResponseAsync<T>(int records);
    }
}
