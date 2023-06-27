using StoreBasicCRUD.ApplicationCoreStructure.ApplicationDtos.Shared.ServiceResponses.Queries;
using StoreBasicCRUD.ApplicationCoreStructure.ApplicationEntities.Responses.Queries;


namespace StoreBasicCRUD.ApplicationCoreStructure.ApplicationHelpers.ServicesResponses.Queries.Bases
{
    public abstract class BaseApplicationServiceQueryResponseHelper
    {
        public abstract Task<ApplicationServiceQueryResponseDto<T>> ResponseAsync<T>(ApplicationCollectorQueryResponseEntity<T> collectorEntityResponse);
    }
}
