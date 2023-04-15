using Microsoft.AspNetCore.Http;
using POS.Infraestructure.Helpers.Application.Commons.Collectors.Exceptions.Bases;
using POS.Infraestructure.SupportEntities.Commons.Collectors.Application;
using POS.Utilities.Commons.Consts;

namespace POS.Infraestructure.Helpers.Application.Commons.Collectors.Exceptions
{
    public class QueryApplicationExceptionBasicCollectorHelper : BaseQueryApplicationExceptionBasicCollectorHelper
    {
        public override async Task<QueryApplicationCollectorEntity<T>> ResponseAsync<T>(int customerErrorCode, string? messageErrorException, int? hResultException, string? sourceException)
        {
            QueryApplicationCollectorEntity<T> response= new ();
            if (hResultException is not null && sourceException is not null)
            {
                if (hResultException == -2146232060 || sourceException == "Core Microsoft SqlClient Data Provider")
                {
                    response.MessageResponse = ReplyMessage.MESSAGE_UNAVAILABLESERVICE;
                    response.HttpStatus = StatusCodes.Status503ServiceUnavailable;
                }
                else
                {
                    response.MessageResponse = ReplyMessage.MESSAGE_FAILED;
                    response.HttpStatus = StatusCodes.Status500InternalServerError;
                }
            }
            else
            {
                response.MessageResponse = ReplyMessage.MESSAGE_FAILED;
                response.HttpStatus = StatusCodes.Status500InternalServerError;
            }

            response.IsSuccess = false;
            response.Information = "Ocurrio un inconveniente de tipo " + customerErrorCode + "!";

            return await Task.FromResult(response);
        }
    }
}
