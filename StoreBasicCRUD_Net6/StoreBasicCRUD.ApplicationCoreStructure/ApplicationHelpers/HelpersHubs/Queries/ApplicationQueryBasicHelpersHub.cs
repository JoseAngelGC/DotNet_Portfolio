using StoreBasicCRUD.ApplicationCoreStructure.ApplicationDtos.Products.EntitiesDtos;
using StoreBasicCRUD.ApplicationCoreStructure.ApplicationDtos.Shared.Requests;
using StoreBasicCRUD.ApplicationCoreStructure.ApplicationDtos.Shared.ServiceResponses.Queries;
using StoreBasicCRUD.ApplicationCoreStructure.ApplicationEntities.Responses.Queries;
using StoreBasicCRUD.ApplicationCoreStructure.ApplicationHelpers.Collectors.Exceptions.Queries;
using StoreBasicCRUD.ApplicationCoreStructure.ApplicationHelpers.Collectors.FilterData;
using StoreBasicCRUD.ApplicationCoreStructure.ApplicationHelpers.Collectors.NotFound.Queries;
using StoreBasicCRUD.ApplicationCoreStructure.ApplicationHelpers.Collectors.OrganizateData;
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

        public async Task<ApplicationCollectorQueryResponseEntity<T>> BasicCollectorQueryNotFoundDataAsync<T>(int records)
        {
            ApplicationBasicCollectorQueryNotFoundHelper basicCollectorQueryNotFoundHelper = new();
            return await basicCollectorQueryNotFoundHelper.ResponseAsync<T>(records);
        }

        public async Task<ApplicationCollectorQueryResponseEntity<T>> BasicCollectorQuerySuccessfulAsync<T>(T repositoryResponse)
        {
            ApplicationBasicCollectorQuerySuccessHelper basicCollectorQuerySuccessHelper = new();
            return await basicCollectorQuerySuccessHelper.ResponseAsync(repositoryResponse);
        }

        public async Task<ApplicationServiceQueryResponseDto<T>> QueryServiceResponseAsync<T>(ApplicationCollectorQueryResponseEntity<T> collectorEntityResponse)
        {
            ApplicationServiceQueryResponseHelper serviceQueryResponseHelper = new();
            return await serviceQueryResponseHelper.ResponseAsync(collectorEntityResponse);
        }

        public async Task<ApplicationCollectorQueryResponseEntity<List<T>>> BasicCollectorQueryOrganizateDataAsync<T>(CommonFiltersRequestDto filters, IQueryable<T> items)
        {
            BasicCollectorOrganizateDataHelper basicCollectorOrganizateDataHelper = new();
            var organizatedListResponse = await basicCollectorOrganizateDataHelper.OrderingAndPaginateDataAsync(filters, items);
            var successfulCollectorResponse = await BasicCollectorQuerySuccessfulAsync(organizatedListResponse.ToList());
            
            //Calcule total records and paginates
            if (items is not null)
            {
                successfulCollectorResponse.TotalRecords = items.Count();
                var totalRecords = Convert.ToDouble(items.Count());
                successfulCollectorResponse.TotalPaginates = Convert.ToInt32(Math.Ceiling(totalRecords / filters.NumberRecordsPage));
            }

            return await Task.FromResult(successfulCollectorResponse);
        }
        public async Task<IQueryable<ProductDto>> BasicCollectorQueryFilterDataAsync(CommonFiltersRequestDto filters, IQueryable<ProductDto> items)
        {
            BasicCollectorApplyFiltersHelper basicCollectorApplyFiltersHelper = new();
            return await basicCollectorApplyFiltersHelper.FilterDataAsync(filters, items);
        }
    }
}
