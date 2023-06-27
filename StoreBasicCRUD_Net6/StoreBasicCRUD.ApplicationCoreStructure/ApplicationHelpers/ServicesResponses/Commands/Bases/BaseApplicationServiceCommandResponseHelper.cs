using StoreBasicCRUD.ApplicationCoreStructure.ApplicationDtos.Shared.ServiceResponses.Commands;
using StoreBasicCRUD.ApplicationCoreStructure.ApplicationEntities.Responses.Commands;


namespace StoreBasicCRUD.ApplicationCoreStructure.ApplicationHelpers.ServicesResponses.Commands.Bases
{
    public abstract class BaseApplicationServiceCommandResponseHelper
    {
        public abstract Task<ApplicationServiceCommandResponseDto> ResponseAsync(ApplicationCollectorCommandResponseEntity collectorEntityResponse);
    }
}
