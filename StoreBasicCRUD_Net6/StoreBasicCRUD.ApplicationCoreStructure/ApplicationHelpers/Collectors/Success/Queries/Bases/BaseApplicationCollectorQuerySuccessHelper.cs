using StoreBasicCRUD.ApplicationCoreStructure.ApplicationEntities.Responses.Queries;


namespace StoreBasicCRUD.ApplicationCoreStructure.ApplicationHelpers.Collectors.Success.Queries.Bases
{
    public abstract class BaseApplicationCollectorQuerySuccessHelper
    {
        public abstract Task<ApplicationCollectorQueryResponseEntity<T>> ResponseAsync<T>(T repositoryResponse);
    }
}
