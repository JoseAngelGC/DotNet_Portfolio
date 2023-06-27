using StoreBasicCRUD.ApplicationCoreStructure.ApplicationDtos.Shared.ServiceResponses.Queries;
using StoreBasicCRUD.ApplicationCoreStructure.ApplicationEntities.Responses.Queries;
using StoreBasicCRUD.ApplicationCoreStructure.ApplicationHelpers.ServicesResponses.Queries.Bases;


namespace StoreBasicCRUD.ApplicationCoreStructure.ApplicationHelpers.ServicesResponses.Queries
{
    public class ApplicationServiceQueryResponseHelper : BaseApplicationServiceQueryResponseHelper
    {
        public override async Task<ApplicationServiceQueryResponseDto<T>> ResponseAsync<T>(ApplicationCollectorQueryResponseEntity<T> collectorEntityResponse)
        {
            ApplicationServiceQueryResponseDto<T> response = new()
            {
                IsSuccess = collectorEntityResponse.IsSuccess,
                Data = collectorEntityResponse.Data,
                TotalRecords = collectorEntityResponse.TotalRecords,
                TotalPaginates = collectorEntityResponse.TotalPaginates,
                StatusResponse = collectorEntityResponse.StatusResponse,
                MessageResponse = collectorEntityResponse.MessageResponse,
                Information = collectorEntityResponse.Information,
                ValidationErrors = collectorEntityResponse.ValidationErrors
            };

            return await Task.FromResult(response);
        }
    }
}
