using Microsoft.AspNetCore.Http;
using StoreBasicCRUD.ApplicationCoreStructure.ApplicationEntities.Responses.Commands;
using StoreBasicCRUD.ApplicationCoreStructure.ApplicationHelpers.Collectors.Errors.Commands.Bases;
using StoreBasicCRUD.Utilities.Shared.Consts;

namespace StoreBasicCRUD.ApplicationCoreStructure.ApplicationHelpers.Collectors.Errors.Commands
{
    public class ApplicationBasicCollectorCommandErrorHelper : BaseApplicationCollectorCommandErrorHelper
    {
        public override async Task<ApplicationCollectorCommandResponseEntity> ResponseAsync()
        {
            ApplicationCollectorCommandResponseEntity response = new()
            {
                IsSuccess = false,
                MessageResponse = ReplyMessage.MESSAGE_FAILED,
                StatusResponse = StatusCodes.Status500InternalServerError
            };

            return await Task.FromResult(response);
        }
    }
}
