using StoreBasicCRUD.ApplicationCoreStructure.ApplicationEntities.Responses.Queries;


namespace StoreBasicCRUD.ApplicationCoreStructure.ApplicationHelpers.ServicesResponses.Queries.Bases
{
    public abstract class BaseApplicationServiceQueryResponseHelper
    {
        public abstract Task<ApplicationServiceQueryResponseEntity<T>> ResponseAsync<T>(ApplicationCollectorQueryResponseEntity<T> collectorEntityResponse);
    }
}
