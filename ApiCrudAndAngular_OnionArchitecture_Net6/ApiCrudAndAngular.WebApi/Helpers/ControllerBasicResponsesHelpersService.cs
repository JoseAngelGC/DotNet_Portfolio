using ApiCrudAndAngular.CoreAbstractions.CoreEntities.Utilities.Constants;
using ApiCrudAndAngular.CoreAbstractions.Helpers.ApiControllers.Responses;
using Microsoft.AspNetCore.Mvc;

namespace ApiCrudAndAngular.WebApi.Helpers
{
    public class ControllerBasicResponsesHelpersService : ControllerBase, IControllerBasicResponsesHelpersService
    {
        public async Task<ObjectResult> CustomResponseBasicHelperAsync<T>(T applicationResponse, int statusResponse)
        {
            switch (statusResponse)
            {
                case StatusCodes.Status503ServiceUnavailable:
                    return await Task.FromResult(StatusCode(statusResponse, applicationResponse));

                case StatusCodes.Status500InternalServerError:
                    return await Task.FromResult(StatusCode(statusResponse, applicationResponse));

                case StatusCodes.Status404NotFound:
                    return await Task.FromResult(StatusCode(statusResponse, applicationResponse));

                case StatusCodes.Status400BadRequest:
                    return await Task.FromResult(StatusCode(statusResponse, applicationResponse));

                case StatusCodes.Status201Created:
                    return await Task.FromResult(StatusCode(statusResponse, applicationResponse));

                default:
                    break;
            }

            return await Task.FromResult(Ok(applicationResponse));
        }

        public async Task<object> ExceptionResponseBasicHelperAsync()
        {
            object response = new
            {
                MessageResponse = ReplyMessageConstants.MESSAGE_FAILED,
                Information = "Ocurrio un inconveniente de tipo ...!",
                StatusResponse = 500
            };

            return await Task.FromResult(response);
        }
    }
}
