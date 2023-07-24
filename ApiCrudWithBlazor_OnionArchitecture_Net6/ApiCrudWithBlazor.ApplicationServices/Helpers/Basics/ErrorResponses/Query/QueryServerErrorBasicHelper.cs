using ApiCrudWithBlazor.Core.Abstraction.BasicHelpers.ExecutionFailsResponses.Errors.AbstractsBases;
using ApiCrudWithBlazor.CoreAbstractions.CoreEntities.Dtos.ResponsesDtos;
using ApiCrudWithBlazor.CoreAbstractions.CoreEntities.Utilities.Constants;
using System.Net;


namespace ApiCrudWithBlazor.ApplicationServices.Helpers.Basics.ErrorResponses.Query
{
    public class QueryServerErrorBasicHelper : BaseQueryErrorsHelper
    {
        public override async Task<QueryResponseDto<T>> AttributesValuesResponseAsync<T>()
        {
            QueryResponseDto<T> response = new()
            {
                IsSuccess = false,
                MessageResponse = ReplyMessageConstants.MESSAGE_FAILED,
                StatusResponse = (int)HttpStatusCode.InternalServerError
            };

            return await Task.FromResult(response);
        }
    }
}
