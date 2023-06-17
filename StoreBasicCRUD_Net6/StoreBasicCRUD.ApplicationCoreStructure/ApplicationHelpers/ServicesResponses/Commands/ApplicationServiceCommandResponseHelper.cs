using StoreBasicCRUD.ApplicationCoreStructure.ApplicationEntities.Responses.Commands;
using StoreBasicCRUD.ApplicationCoreStructure.ApplicationHelpers.ServicesResponses.Commands.Bases;


namespace StoreBasicCRUD.ApplicationCoreStructure.ApplicationHelpers.ServicesResponses.Commands
{
    public class ApplicationServiceCommandResponseHelper : BaseApplicationServiceCommandResponseHelper
    {
        public override async Task<ApplicationServiceCommandResponseEntity> ResponseAsync(ApplicationCollectorCommandResponseEntity collectorEntityResponse)
        {
            ApplicationServiceCommandResponseEntity response = new()
            {
                IsSuccess = collectorEntityResponse.IsSuccess,
                RecordsAffected = collectorEntityResponse.RecordsAffected,
                StatusResponse = collectorEntityResponse.StatusResponse,
                MessageResponse = collectorEntityResponse.MessageResponse,
                Information = collectorEntityResponse.Information,
                ValidationErrors = collectorEntityResponse.ValidationErrors
            };

            return await Task.FromResult(response);
        }
    }
}
