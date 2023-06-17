using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using POS.Application.Interfaces.UserServices.Commands.SaveItem;
using POS.Application.Interfaces.UserServices.Queries.GetToken;
using POS.Infraestructure.Helpers.WebApi.Controllers.Commons.Collectors.Exceptions;
using POS.Infraestructure.SupportDtos.Application.RequestsDtos.UserRequestsDtos;

namespace POS.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class UserController : BaseApiUserController
    {
        public UserController(ISaveUserApplicationService saveUserApplicationService, IGetTokenApplicationService tokenApplicationService) : base(saveUserApplicationService, tokenApplicationService)
        {
        }

        [HttpPost("Register")]
        public async Task<IActionResult> SaveUser([FromBody] UserRequestDto requestDto)
        {
            try
            {
                var response = await _saveUserApplicationService.SaveItemAsync(requestDto);
                return await _genericCustomResult.ResponseAsync(response, response.StatusResponse);
            }
            catch (Exception)
            {
                var response = await ControllerExceptionCollectorStatic.ResponseAsync(8300);
                return await Task.FromResult(StatusCode(StatusCodes.Status500InternalServerError, response));
            }
        }

        [AllowAnonymous]
        [HttpPost("Generate/Token")]
        public async Task<IActionResult> CreateToken([FromBody] TokenRequestDto requestDto)
        {
            try
            {
                var response = await _tokenApplicationService.ResponseAsync(requestDto);
                return await _genericCustomResult.ResponseAsync(response, response.StatusResponse);
            }
            catch (Exception)
            {
                var response = await ControllerExceptionCollectorStatic.ResponseAsync(8400);
                return await Task.FromResult(StatusCode(StatusCodes.Status500InternalServerError, response));
            }
        }
    }
}
