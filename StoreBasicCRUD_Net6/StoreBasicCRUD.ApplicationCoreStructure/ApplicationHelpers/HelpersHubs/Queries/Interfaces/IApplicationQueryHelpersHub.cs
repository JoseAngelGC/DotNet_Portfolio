using StoreBasicCRUD.ApplicationCoreStructure.ApplicationDtos.Products.EntitiesDtos;
using StoreBasicCRUD.ApplicationCoreStructure.ApplicationDtos.Shared.Requests;
using StoreBasicCRUD.ApplicationCoreStructure.ApplicationDtos.Shared.ServiceResponses.Queries;
using StoreBasicCRUD.ApplicationCoreStructure.ApplicationEntities.Responses.Queries;


namespace StoreBasicCRUD.ApplicationCoreStructure.ApplicationHelpers.HelpersHubs.Queries.Interfaces
{
    public interface IApplicationQueryHelpersHub
    {
        Task<ApplicationCollectorQueryResponseEntity<T>> BasicCollectorQuerySuccessfulAsync<T>(T repositoryResponse);
        Task<ApplicationCollectorQueryResponseEntity<T>> BasicCollectorQueryExceptionAsync<T>(string? messageErrorException, int? hResultException, string? sourceException);
        Task<ApplicationCollectorQueryResponseEntity<T>> BasicCollectorQueryNotFoundDataAsync<T>(int records);
        Task<IQueryable<ProductDto>> BasicCollectorQueryFilterDataAsync(CommonFiltersRequestDto filters, IQueryable<ProductDto> items);
        Task<ApplicationCollectorQueryResponseEntity<List<T>>> BasicCollectorQueryOrganizateDataAsync<T>(CommonFiltersRequestDto filters, IQueryable<T> items);
        Task<ApplicationServiceQueryResponseDto<T>> QueryServiceResponseAsync<T>(ApplicationCollectorQueryResponseEntity<T> collectorEntityResponse);
    }
}
