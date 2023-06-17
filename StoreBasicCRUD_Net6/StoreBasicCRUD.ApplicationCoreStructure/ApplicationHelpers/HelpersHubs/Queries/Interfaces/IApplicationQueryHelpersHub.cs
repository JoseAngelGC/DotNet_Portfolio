using StoreBasicCRUD.ApplicationCoreStructure.ApplicationEntities.Responses.Queries;


namespace StoreBasicCRUD.ApplicationCoreStructure.ApplicationHelpers.HelpersHubs.Queries.Interfaces
{
    public interface IApplicationQueryHelpersHub
    {
        Task<ApplicationCollectorQueryResponseEntity<T>> BasicCollectorQuerySuccessfulAsync<T>(T repositoryResponse);
        Task<ApplicationCollectorQueryResponseEntity<T>> BasicCollectorQueryExceptionAsync<T>(string? messageErrorException, int? hResultException, string? sourceException);
        Task<ApplicationCollectorQueryResponseEntity<T>> BasicCollectorQueryNotFoundDataAsync<T>(int? records);
        Task<ApplicationServiceQueryResponseEntity<T>> QueryServiceResponseAsync<T>(ApplicationCollectorQueryResponseEntity<T> collectorEntityResponse);
    }
}
