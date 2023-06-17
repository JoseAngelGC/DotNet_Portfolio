using Microsoft.AspNetCore.Http;
using StoreBasicCRUD.ApplicationCoreStructure.ApplicationEntities.Responses.Queries;
using StoreBasicCRUD.ApplicationCoreStructure.ApplicationHelpers.Collectors.Success.Queries.Bases;
using StoreBasicCRUD.Utilities.Shared.Consts;

namespace StoreBasicCRUD.ApplicationCoreStructure.ApplicationHelpers.Collectors.Success.Queries
{
    public class ApplicationBasicCollectorQuerySuccessHelper : BaseApplicationCollectorQuerySuccessHelper
    {
        public override async Task<ApplicationCollectorQueryResponseEntity<T>> ResponseAsync<T>(T repositoryResponse)
        {
            ApplicationCollectorQueryResponseEntity<T> response = new()
            {
                IsSuccess = true,
                Data = repositoryResponse,
                MessageResponse = ReplyMessage.MESSAGE_QUERY_SUCCESSFULL,
                StatusResponse = StatusCodes.Status200OK
            };

            return await Task.FromResult(response);
        }
    }
}
