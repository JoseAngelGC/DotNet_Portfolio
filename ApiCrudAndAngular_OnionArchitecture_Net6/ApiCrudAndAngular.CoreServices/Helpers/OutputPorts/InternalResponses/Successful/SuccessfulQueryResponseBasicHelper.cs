using ApiCrudAndAngular.CoreAbstractions.CoreEntities.Dtos.OutputPortDtos.Responses;
using ApiCrudAndAngular.CoreAbstractions.CoreEntities.Utilities.Constants;
using ApiCrudAndAngular.CoreAbstractions.Helpers.OutputPorts.Responses.Successful.AbstractsBases;
using System.Net;

namespace ApiCrudAndAngular.CoreServices.Helpers.OutputPorts.InternalResponses.Successful
{
    internal class SuccessfulQueryResponseBasicHelper : BaseSuccessfulQueryResponseHelper
    {
        public override async Task<QueryResponseDto<T>> AttributesValuesAsync<T>(T data)
        {
            QueryResponseDto<T> response = new()
            {
                IsSuccess = true,
                Data = data,
                MessageResponse = ReplyMessageConstants.MESSAGE_QUERY_SUCCESSFULL,
                StatusResponse = (int)HttpStatusCode.OK
            };

            return await Task.FromResult(response);
        }
    }
}
