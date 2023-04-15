using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using POS.Infraestructure.Interfaces.Application.Commons.Responses;

namespace POS.Infraestructure.Helpers.WebApi.Controllers.Commons.Responses
{
    public  class GenericCustomResult : ControllerBase, IGenericCustomResult
    {
        public async Task<ObjectResult> ResponseAsync<T>(T response, int statusResponse)
        {
            switch (statusResponse)
            {
                case StatusCodes.Status503ServiceUnavailable:
                    return await Task.FromResult(StatusCode(statusResponse, response));

                case StatusCodes.Status500InternalServerError:
                    return await Task.FromResult(StatusCode(statusResponse, response));

                case StatusCodes.Status404NotFound:
                    return await Task.FromResult(StatusCode(statusResponse, response));

                case StatusCodes.Status400BadRequest:
                    return await Task.FromResult(StatusCode(statusResponse, response));

                case StatusCodes.Status201Created:
                    return await Task.FromResult(StatusCode(statusResponse, response));

                default:
                    break;
            }
            
            return await Task.FromResult(Ok(response));
        }
    }
}
