using StoreBasicCRUD.ApplicationCoreStructure.ApplicationEntities.Responses.Commands;
using StoreBasicCRUD.ApplicationCoreStructure.ApplicationHelpers.Collectors.Errors.Commands;
using StoreBasicCRUD.ApplicationCoreStructure.ApplicationHelpers.Collectors.Fails.Commands.Bases;
using StoreBasicCRUD.ApplicationCoreStructure.ApplicationHelpers.Collectors.NotFound.Commands;

namespace StoreBasicCRUD.ApplicationCoreStructure.ApplicationHelpers.Collectors.Fails.Commands
{
    public class ApplicationBasicCollectorCommandExecutionFailedHelper : BaseApplicationCollectorCommandFailsHelper
    {
        public override async Task<ApplicationCollectorCommandResponseEntity> ResponseAsync(int? existRegister)
        {
            ApplicationCollectorCommandResponseEntity response;
            switch (existRegister)
            {
                case 0:
                    ApplicationBasicCollectorCommandNotFoundHelper basicCollectorCommandNotFoundHelper = new();
                    response = await basicCollectorCommandNotFoundHelper.ResponseAsync();
                    break;
                case 1:
                    ApplicationBasicCollectorCommandErrorHelper basicCollectorCommandErrorHelper = new();
                    response = await basicCollectorCommandErrorHelper.ResponseAsync();
                    break;
                default:
                    ApplicationBasicCollectorCommandErrorHelper basicCollectorCommandErrorHelperr = new();
                    response = await basicCollectorCommandErrorHelperr.ResponseAsync();
                    break;
            }

            return response;
        }
    }
}
