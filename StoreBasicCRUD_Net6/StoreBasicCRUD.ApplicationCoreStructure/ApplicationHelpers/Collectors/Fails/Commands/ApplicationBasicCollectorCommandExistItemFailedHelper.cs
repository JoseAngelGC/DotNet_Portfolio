using StoreBasicCRUD.ApplicationCoreStructure.ApplicationEntities.Responses.Commands;
using StoreBasicCRUD.ApplicationCoreStructure.ApplicationHelpers.Collectors.Errors.Commands;
using StoreBasicCRUD.ApplicationCoreStructure.ApplicationHelpers.Collectors.Exist.Commands;
using StoreBasicCRUD.ApplicationCoreStructure.ApplicationHelpers.Collectors.Fails.Commands.Bases;


namespace StoreBasicCRUD.ApplicationCoreStructure.ApplicationHelpers.Collectors.Fails.Commands
{
    public class ApplicationBasicCollectorCommandExistItemFailedHelper : BaseApplicationCollectorCommandFailsHelper
    {
        public override async Task<ApplicationCollectorCommandResponseEntity> ResponseAsync(int? existRegister)
        {
            ApplicationCollectorCommandResponseEntity response = new();
            switch (existRegister)
            {
                case 0:
                    ApplicationBasicCollectorCommandErrorHelper basicCollectorCommandErrorHelper = new();
                    response = await basicCollectorCommandErrorHelper.ResponseAsync();
                    break;
                case 1:
                    ApplicationBasicCollectorCommandExistItemHelper basicCollectorCommandExistItemHelper = new();
                    response = await basicCollectorCommandExistItemHelper.ResponseAsync();
                    break;

            }

            return response;
        }
    }
}
