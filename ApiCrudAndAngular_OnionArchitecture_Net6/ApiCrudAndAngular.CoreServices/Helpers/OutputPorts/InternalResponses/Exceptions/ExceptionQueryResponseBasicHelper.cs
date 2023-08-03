using ApiCrudAndAngular.CoreAbstractions.CoreEntities.Dtos.OutputPortDtos.Responses;
using ApiCrudAndAngular.CoreAbstractions.CoreEntities.Utilities.Constants;
using ApiCrudAndAngular.CoreAbstractions.Helpers.OutputPorts.Responses.Exceptions.AbstractsBases;
using System.Net;

namespace ApiCrudAndAngular.CoreServices.Helpers.OutputPorts.InternalResponses.Exceptions
{
    internal class ExceptionQueryResponseBasicHelper : BaseExceptionQueryResponseHelper
    {
        public override async Task<QueryResponseDto<T>> AttributesValuesAsync<T>(string? messageErrorException, int? hResultException, string? sourceException)
        {
            QueryResponseDto<T> response = new();
            if (hResultException is not null && sourceException is not null)
            {
                if (hResultException == -2146232060 || sourceException == "Core Microsoft SqlClient Data Provider")
                {
                    response.MessageResponse = ReplyMessageConstants.MESSAGE_UNAVAILABLESERVICE;
                    response.StatusResponse = (int)HttpStatusCode.ServiceUnavailable;
                }
                else
                {
                    response.MessageResponse = ReplyMessageConstants.MESSAGE_FAILED;
                    response.StatusResponse = (int)HttpStatusCode.InternalServerError;
                }
            }
            else
            {
                response.MessageResponse = ReplyMessageConstants.MESSAGE_FAILED;
                response.StatusResponse = (int)HttpStatusCode.InternalServerError;
            }

            response.IsSuccess = false;
            response.Information = "Ocurrio un inconveniente de tipo ...!";

            return await Task.FromResult(response);
        }
    }
}
