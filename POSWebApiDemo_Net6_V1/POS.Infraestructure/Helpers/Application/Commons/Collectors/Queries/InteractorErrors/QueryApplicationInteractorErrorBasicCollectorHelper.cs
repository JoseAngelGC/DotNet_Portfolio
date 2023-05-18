using Microsoft.AspNetCore.Http;
using POS.Infraestructure.Helpers.Application.Commons.Collectors.Queries.InteractorErrors.Bases;
using POS.Infraestructure.SupportEntities.Commons.Collectors.Application;
using POS.Utilities.Commons.Consts;


namespace POS.Infraestructure.Helpers.Application.Commons.Collectors.Queries.InteractorErrors
{
    public class QueryApplicationInteractorErrorBasicCollectorHelper : BaseQueryApplicationInteractorErrorBasicCollectorHelper
    {
        public override async Task<QueryApplicationCollectorEntity<T>> ResponseAsync<T>(bool isSuccess, string controlMessage, int? customErrorCode)
        {
            QueryApplicationCollectorEntity<T> response = new();
            switch (controlMessage)
            {
                case ControlEvent.MESSAGE_UNAVAILABLE:

                    response.MessageResponse = ReplyMessage.MESSAGE_UNAVAILABLESERVICE;
                    response.HttpStatus = StatusCodes.Status503ServiceUnavailable;
                    break;
                case ControlEvent.MESSAGE_UNCONTROLLEDEXCEPTION:
                    response.MessageResponse = ReplyMessage.MESSAGE_FAILED;
                    response.HttpStatus = StatusCodes.Status500InternalServerError;
                    break;
            }

            response.IsSuccess = isSuccess;
            response.Information = "Se presento un inconveniente de tipo " + customErrorCode + "!";

            return await Task.FromResult(response);
        }
    }
}
