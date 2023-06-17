using StoreBasicCRUD.ApplicationCoreStructure.ApplicationEntities.Responses.Queries;

namespace StoreBasicCRUD.ApplicationCoreStructure.ApplicationHelpers.Collectors.Exceptions.Queries.Bases
{
    public abstract class BaseApplicationCollectorQueryExceptionHelper
    {
        public abstract Task<ApplicationCollectorQueryResponseEntity<T>> ResponseAsync<T>(string? messageErrorException, int? hResultException, string? sourceException);
    }
}
