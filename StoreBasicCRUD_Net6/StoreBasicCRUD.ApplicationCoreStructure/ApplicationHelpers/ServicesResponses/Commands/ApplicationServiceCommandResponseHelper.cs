using StoreBasicCRUD.ApplicationCoreStructure.ApplicationDtos.Shared.ServiceResponses.Commands;
using StoreBasicCRUD.ApplicationCoreStructure.ApplicationEntities.Responses.Commands;
using StoreBasicCRUD.ApplicationCoreStructure.ApplicationHelpers.ServicesResponses.Commands.Bases;


namespace StoreBasicCRUD.ApplicationCoreStructure.ApplicationHelpers.ServicesResponses.Commands
{
    public class ApplicationServiceCommandResponseHelper : BaseApplicationServiceCommandResponseHelper
    {
        public override async Task<ApplicationServiceCommandResponseDto> ResponseAsync(ApplicationCollectorCommandResponseEntity collectorEntityResponse)
        {
            ApplicationServiceCommandResponseDto response = new()
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
