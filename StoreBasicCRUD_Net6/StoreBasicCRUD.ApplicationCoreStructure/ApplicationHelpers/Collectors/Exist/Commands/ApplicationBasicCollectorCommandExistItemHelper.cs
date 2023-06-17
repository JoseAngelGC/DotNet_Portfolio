using Microsoft.AspNetCore.Http;
using StoreBasicCRUD.ApplicationCoreStructure.ApplicationEntities.Responses.Commands;
using StoreBasicCRUD.ApplicationCoreStructure.ApplicationHelpers.Collectors.Exist.Commands.Bases;
using StoreBasicCRUD.Utilities.Shared.Consts;

namespace StoreBasicCRUD.ApplicationCoreStructure.ApplicationHelpers.Collectors.Exist.Commands
{
    public class ApplicationBasicCollectorCommandExistItemHelper : BaseApplicationCollectorCommandExistItemHelper
    {
        public override async Task<ApplicationCollectorCommandResponseEntity> ResponseAsync()
        {
            ApplicationCollectorCommandResponseEntity response = new()
            {
                IsSuccess = false,
                MessageResponse = ReplyMessage.MESSAGE_EXIST,
                StatusResponse = StatusCodes.Status400BadRequest
            };

            return await Task.FromResult(response);
        }
    }
}
