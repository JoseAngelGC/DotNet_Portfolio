using ApiCrudAndAngular.CoreAbstractions.CoreEntities.Dtos.OutputPortDtos.Responses;
using ApiCrudAndAngular.CoreAbstractions.CoreEntities.Utilities.Constants;
using ApiCrudAndAngular.CoreAbstractions.Helpers.OutputPorts.Responses.Errors.AbstractsBases;
using System.Net;

namespace ApiCrudAndAngular.CoreServices.Helpers.OutputPorts.InternalResponses.Errors.Queries
{
    internal class NotFoundErrorQueryResponseBasicHelper : BaseErrorQueryResponseHelper
    {
        public override async Task<QueryResponseDto<T>> AttributesValuesAsync<T>()
        {
            QueryResponseDto<T> response = new()
            {
                IsSuccess = false,
                MessageResponse = ReplyMessageConstants.MESSAGE_QUERY_EMPTY,
                StatusResponse = (int)HttpStatusCode.NotFound
            };

            return await Task.FromResult(response);
        }
    }
}
