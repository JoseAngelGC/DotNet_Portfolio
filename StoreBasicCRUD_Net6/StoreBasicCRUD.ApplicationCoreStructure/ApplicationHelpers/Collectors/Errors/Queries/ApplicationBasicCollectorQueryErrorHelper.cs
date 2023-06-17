using Microsoft.AspNetCore.Http;
using StoreBasicCRUD.ApplicationCoreStructure.ApplicationEntities.Responses.Queries;
using StoreBasicCRUD.ApplicationCoreStructure.ApplicationHelpers.Collectors.Errors.Queries.Bases;
using StoreBasicCRUD.Utilities.Shared.Consts;

namespace StoreBasicCRUD.ApplicationCoreStructure.ApplicationHelpers.Collectors.Errors.Queries
{
    public class ApplicationBasicCollectorQueryErrorHelper : BaseApplicationCollectorQueryErrorHelper
    {
        public override async Task<ApplicationCollectorQueryResponseEntity<T>> ResponseAsync<T>()
        {
            ApplicationCollectorQueryResponseEntity<T> response = new()
            {
                IsSuccess = false,
                MessageResponse = ReplyMessage.MESSAGE_FAILED,
                StatusResponse = StatusCodes.Status500InternalServerError
            };

            return await Task.FromResult(response);
        }
    }
}
