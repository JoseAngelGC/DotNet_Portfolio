using StoreBasicCRUD.ApplicationCoreStructure.ApplicationEntities.Responses.Queries;
using StoreBasicCRUD.ApplicationCoreStructure.ApplicationHelpers.Collectors.Exceptions.Queries;
using StoreBasicCRUD.ApplicationCoreStructure.ApplicationHelpers.Collectors.NotFound.Queries;
using StoreBasicCRUD.ApplicationCoreStructure.ApplicationHelpers.Collectors.Success.Queries;
using StoreBasicCRUD.ApplicationCoreStructure.ApplicationHelpers.HelpersHubs.Queries.Interfaces;
using StoreBasicCRUD.ApplicationCoreStructure.ApplicationHelpers.ServicesResponses.Queries;

namespace StoreBasicCRUD.ApplicationCoreStructure.ApplicationHelpers.HelpersHubs.Queries
{
    public class ApplicationQueryBasicHelpersHub : IApplicationQueryHelpersHub
    {
        public async Task<ApplicationCollectorQueryResponseEntity<T>> BasicCollectorQueryExceptionAsync<T>(string? messageErrorException, int? hResultException, string? sourceException)
        {
            ApplicationBasicCollectorQueryExceptionHelper basicCollectorQueryExceptionHelper = new();
            return await basicCollectorQueryExceptionHelper.ResponseAsync<T>(messageErrorException, hResultException, sourceException);
        }

        public async Task<ApplicationCollectorQueryResponseEntity<T>> BasicCollectorQueryNotFoundDataAsync<T>(int? records)
        {
            ApplicationBasicCollectorQueryNotFoundHelper basicCollectorQueryNotFoundHelper = new();
            return await basicCollectorQueryNotFoundHelper.ResponseAsync<T>(records);
        }

        public async Task<ApplicationCollectorQueryResponseEntity<T>> BasicCollectorQuerySuccessfulAsync<T>(T repositoryResponse)
        {
            ApplicationBasicCollectorQuerySuccessHelper basicCollectorQuerySuccessHelper = new();
            return await basicCollectorQuerySuccessHelper.ResponseAsync(repositoryResponse);
        }

        public async Task<ApplicationServiceQueryResponseEntity<T>> QueryServiceResponseAsync<T>(ApplicationCollectorQueryResponseEntity<T> collectorEntityResponse)
        {
            ApplicationServiceQueryResponseHelper serviceQueryResponseHelper = new();
            return await serviceQueryResponseHelper.ResponseAsync(collectorEntityResponse);
        }
    }
}
