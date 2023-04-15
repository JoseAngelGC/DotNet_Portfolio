using Microsoft.AspNetCore.Http;
using POS.Infraestructure.Helpers.Application.Commons.Collectors.InteractorErrors.Bases;
using POS.Infraestructure.SupportEntities.Commons.Collectors.Application;
using POS.Utilities.Commons.Consts;


namespace POS.Infraestructure.Helpers.Application.Commons.Collectors.InteractorErrors
{
    public class QueryApplicationInteractorErrorBasicCollectorHelper : BaseQueryApplicationInteractorErrorBasicCollectorHelper
    {
        public override async Task<QueryApplicationCollectorEntity<T>> ResponseAsync<T>(bool isSuccess, string controlMessage, int? customErrorCode)
        {
            QueryApplicationCollectorEntity<T> response = new ();
            response.IsSuccess = isSuccess;
            response.Information = "Se presento un inconveniente de tipo " + customErrorCode + "!";
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

            return await Task.FromResult(response);
        }
    }
}
