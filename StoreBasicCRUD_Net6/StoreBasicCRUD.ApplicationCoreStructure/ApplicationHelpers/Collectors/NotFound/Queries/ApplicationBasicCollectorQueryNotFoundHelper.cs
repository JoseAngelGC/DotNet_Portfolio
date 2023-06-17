using Microsoft.AspNetCore.Http;
using StoreBasicCRUD.ApplicationCoreStructure.ApplicationEntities.Responses.Queries;
using StoreBasicCRUD.ApplicationCoreStructure.ApplicationHelpers.Collectors.NotFound.Queries.Bases;
using StoreBasicCRUD.Utilities.Shared.Consts;

namespace StoreBasicCRUD.ApplicationCoreStructure.ApplicationHelpers.Collectors.NotFound.Queries
{
    public class ApplicationBasicCollectorQueryNotFoundHelper : BaseApplicationCollectorQueryNotFoundHelper
    {
        public override async Task<ApplicationCollectorQueryResponseEntity<T>> ResponseAsync<T>(int? records)
        {
            ApplicationCollectorQueryResponseEntity<T> response = new()
            {
                IsSuccess = true,
                MessageResponse = ReplyMessage.MESSAGE_QUERY_EMPTY,
                StatusResponse = StatusCodes.Status404NotFound,
                Records = records
            };

            return await Task.FromResult(response);
        }
    }
}
