using StoreBasicCRUD.ApplicationCoreStructure.ApplicationEntities.Responses.Queries;


namespace StoreBasicCRUD.ApplicationCoreStructure.ApplicationHelpers.Collectors.Errors.Queries.Bases
{
    public abstract class BaseApplicationCollectorQueryErrorHelper
    {
        public abstract Task<ApplicationCollectorQueryResponseEntity<T>> ResponseAsync<T>();
    }
}
