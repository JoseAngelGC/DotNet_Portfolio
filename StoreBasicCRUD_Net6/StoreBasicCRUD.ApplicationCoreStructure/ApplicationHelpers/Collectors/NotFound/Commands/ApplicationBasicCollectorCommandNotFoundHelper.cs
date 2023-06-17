using Microsoft.AspNetCore.Http;
using StoreBasicCRUD.ApplicationCoreStructure.ApplicationEntities.Responses.Commands;
using StoreBasicCRUD.ApplicationCoreStructure.ApplicationHelpers.Collectors.NotFound.Commands.Bases;
using StoreBasicCRUD.Utilities.Shared.Consts;


namespace StoreBasicCRUD.ApplicationCoreStructure.ApplicationHelpers.Collectors.NotFound.Commands
{
    public class ApplicationBasicCollectorCommandNotFoundHelper : BaseApplicationCollectorCommandNotFoundHelper
    {
        public override async Task<ApplicationCollectorCommandResponseEntity> ResponseAsync()
        {
            ApplicationCollectorCommandResponseEntity response = new()
            {
                IsSuccess = false,
                MessageResponse = ReplyMessage.MESSAGE_QUERY_EMPTY,
                StatusResponse = StatusCodes.Status404NotFound
            };

            return await Task.FromResult(response);
        }
    }
}
