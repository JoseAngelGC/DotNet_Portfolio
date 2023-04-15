using ApiMovieStoreDemo1_Net5.Models.Dtos.UserAuthDtos;
using ApiMovieStoreDemo1_Net5.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ApiMovieStoreDemo1_Net5.Controllers
{
    [Authorize]
    [Route("api/v{version:apiVersion}/Users")]
    [ApiController]
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "ApiUsers_v1")]

    public class UsersV1_Controller : ControllerBase
    {
        private readonly IUserAuthService _iuaService;
        public UsersV1_Controller(IUserAuthService userAuthService)
        {
            _iuaService = userAuthService;
        }

        /// <summary>
        /// Muestra los usuarios registrados.
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> GetUsersAuth()
        {
            try
            {
                var response = await _iuaService.GetUsersAuthService();
                if (response.OperationCodeServiceResponse == -1)
                {
                    ModelState.AddModelError("", $"{response.MessageServiceResponse}");
                    return StatusCode(503, ModelState);
                }

                if (response.OperationCodeServiceResponse == -2)
                {
                    ModelState.AddModelError("", $"{response.MessageServiceResponse}");
                    return StatusCode(500, ModelState);
                }

                if (response.MessageServiceResponse.Equals("NotFound"))
                {
                    response.MessageServiceResponse = "No hay registros insertados!";
                    return StatusCode(201, response);
                }

                return Ok(response);
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Ocurrio un inconveniente de tipo C700E!");
                return StatusCode(500, ModelState);
            }

        }

        /// <summary>
        /// Registra o guarda un usuario de acuerdo a los parámetros enviados.
        /// </summary>
        /// <param name="userAuthRegisterDto">Los parámetros userAlias y password se enviarán en el request body para realizar el registro del usuario.</param>
        /// <returns></returns>

        [HttpPost("Register")]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> UserRegister(UserAuthRegisterDto userAuthRegisterDto)
        {
            try
            {
                if (userAuthRegisterDto == null)
                {
                    return BadRequest(ModelState);
                }

                var response = await _iuaService.UserAuthRegister(userAuthRegisterDto);
                if (response.OperationCodeServiceResponse == -1)
                {
                    ModelState.AddModelError("", $"{response.MessageServiceResponse}");
                    return StatusCode(503, ModelState);
                }

                if (response.OperationCodeServiceResponse == -2)
                {
                    ModelState.AddModelError("", $"{response.MessageServiceResponse}");
                    return StatusCode(500, ModelState);
                }

                if (response.MessageServiceResponse.Equals("Exist"))
                {
                    response.MessageServiceResponse = "El Usuario ya existe!";
                    return NotFound(response);
                }

                return StatusCode(201, response);
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Ocurrio un inconveniente de tipo C702E!");
                return StatusCode(500, ModelState);
            }
        }

        /// <summary>
        /// Autentica un usuario registrado
        /// </summary>
        /// <param name="userAuthLoginDto">Los parámetros userAlias y password se enviarán en el request body para realizar la autenticación del usuario.</param>
        /// <returns>Token</returns>

        [AllowAnonymous]
        [HttpPost("Login")]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> UserLogin(UserAuthLoginDto userAuthLoginDto)
        {
            try
            {
                if (userAuthLoginDto == null)
                {
                    return BadRequest(ModelState);
                }

                var response = await _iuaService.UserAuthLogin(userAuthLoginDto);
                if (response.OperationCodeServiceResponse == -1)
                {
                    ModelState.AddModelError("", $"{response.MessageServiceResponse}");
                    return StatusCode(503, ModelState);
                }

                if (response.OperationCodeServiceResponse == -2)
                {
                    ModelState.AddModelError("", $"{response.MessageServiceResponse}");
                    return StatusCode(500, ModelState);
                }

                if (response.MessageServiceResponse.Equals("NotFound"))
                {
                    response.MessageServiceResponse = "No existe el Usuario!";
                    return NotFound(response);
                }

                if (response.MessageServiceResponse.Equals("BadCredentials"))
                {
                    ModelState.AddModelError("", "El Usuario o el password son incorrectos!");
                    return StatusCode(400, ModelState);
                }

                return StatusCode(201, response);
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Ocurrio un inconveniente de tipo C707E!");
                return StatusCode(500, ModelState);
            }
        }

    }
}
