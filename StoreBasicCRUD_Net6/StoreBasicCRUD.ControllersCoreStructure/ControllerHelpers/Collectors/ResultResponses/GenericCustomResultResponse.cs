using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreBasicCRUD.ControllersCoreStructure.ControllerHelpers.Collectors.ResultResponses.Interfaces;


namespace StoreBasicCRUD.ControllersCoreStructure.ControllerHelpers.Collectors.ResultResponses
{
    public class GenericCustomResultResponse : ControllerBase, IGenericCustomResultResponse
    {
        public async Task<ObjectResult> ResponseAsync<T>(T applicationResponse, int statusResponse)
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
    }
}
