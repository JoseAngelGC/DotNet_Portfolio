using StoreBasicCRUD.ApplicationCoreStructure.ApplicationEntities.Responses.Queries;
using StoreBasicCRUD.ApplicationCoreStructure.ApplicationHelpers.ServicesResponses.Queries.Bases;


namespace StoreBasicCRUD.ApplicationCoreStructure.ApplicationHelpers.ServicesResponses.Queries
{
    public class ApplicationServiceQueryResponseHelper : BaseApplicationServiceQueryResponseHelper
    {
        public override async Task<ApplicationServiceQueryResponseEntity<T>> ResponseAsync<T>(ApplicationCollectorQueryResponseEntity<T> collectorEntityResponse)
        {
            ApplicationServiceQueryResponseEntity<T> response = new()
            {
                IsSuccess = collectorEntityResponse.IsSuccess,
                Data = collectorEntityResponse.Data,
                Records = collectorEntityResponse.Records,
                StatusResponse = collectorEntityResponse.StatusResponse,
                MessageResponse = collectorEntityResponse.MessageResponse,
                Information = collectorEntityResponse.Information,
                ValidationErrors = collectorEntityResponse.ValidationErrors
            };

            return await Task.FromResult(response);
        }
    }
}
