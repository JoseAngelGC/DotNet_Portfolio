using ApiCrudWithBlazor.Core.Abstraction.BasicHelpers.CompletedExecutionResponses.Success.AbstractsBases;
using ApiCrudWithBlazor.CoreAbstractions.CoreEntities.Dtos.ResponsesDtos;
using ApiCrudWithBlazor.CoreAbstractions.CoreEntities.Utilities.Constants;
using System.Net;

namespace ApiCrudWithBlazor.ApplicationServices.Helpers.Basics.SuccessfulResponses.Query
{
    public class SuccessfulQueryBasicHelper : BaseSuccessfulQueryHelper
    {
        public override async Task<QueryResponseDto<T>> AttributesValuesResponseAsync<T>(T data)
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
