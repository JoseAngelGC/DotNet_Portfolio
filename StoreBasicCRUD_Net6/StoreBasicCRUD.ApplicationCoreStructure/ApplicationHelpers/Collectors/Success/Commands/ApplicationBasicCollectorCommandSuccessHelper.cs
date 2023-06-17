using Microsoft.AspNetCore.Http;
using StoreBasicCRUD.ApplicationCoreStructure.ApplicationEntities.Responses.Commands;
using StoreBasicCRUD.ApplicationCoreStructure.ApplicationHelpers.Collectors.Success.Commands.Bases;
using StoreBasicCRUD.Utilities.Shared.Consts;

namespace StoreBasicCRUD.ApplicationCoreStructure.ApplicationHelpers.Collectors.Success.Commands
{
    public class ApplicationBasicCollectorCommandSuccessHelper : BaseApplicationCollectorCommandSuccessHelper
    {
        public override async Task<ApplicationCollectorCommandResponseEntity> ResponseAsync(int? recordsAffected, string messageResponse)
        {
            ApplicationCollectorCommandResponseEntity response = new();
            switch (messageResponse)
            {
                case ReplyMessage.MESSAGE_SAVE:
                    response.StatusResponse = StatusCodes.Status201Created;
                    break;
                case ReplyMessage.MESSAGE_UPDATE:
                    response.StatusResponse = StatusCodes.Status200OK;
                    break;
                case ReplyMessage.MESSAGE_DELETE:
                    response.StatusResponse = StatusCodes.Status200OK;
                    break;
            }

            response.IsSuccess = true;
            response.RecordsAffected = recordsAffected;
            response.MessageResponse = messageResponse;

            return await Task.FromResult(response);
        }
    }
}
