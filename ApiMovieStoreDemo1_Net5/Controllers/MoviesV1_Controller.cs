using ApiMovieStoreDemo1_Net5.Models.Dtos.MovieDtos;
using ApiMovieStoreDemo1_Net5.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ApiMovieStoreDemo1_Net5.Controllers
{
    [Authorize]
    [Route("api/v{version:apiVersion}/Movies")]
    [ApiController]
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "ApiMovies_v1")]

    public class MoviesV1_Controller : ControllerBase
    {
        private readonly IMovieService _imvService;
        public MoviesV1_Controller(IMovieService imovieService)
        {
            _imvService = imovieService;
        }


        /// <summary>
        /// Muestra todas las peliculas.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> GetMovies()
        {
            try
            {
                var response = await _imvService.GetMoviesService();
                if (response.OperationCodeServiceResponse == -1)
                {
                    ModelState.AddModelError("", $"{response.MessageServiceResponse}");
                    return NotFound(ModelState);
                }

                if (response.OperationCodeServiceResponse == -2)
                {
                    ModelState.AddModelError("", $"{response.MessageServiceResponse}");
                    return StatusCode(500, ModelState);
                }

                return Ok(response);
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Ocurrio un inconveniente de tipo C800E!");
                return StatusCode(500, ModelState);
            }

        }


        /// <summary>
        /// Muestra una pelicula de acuerdo al parámetro id enviado.
        /// </summary>
        /// <param name="id">Parámetro id de la pelicula</param>
        /// <returns></returns>
        [HttpGet("Movie/{id:int}")]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> GetMovie(int id)
        {
            try
            {
                var response = await _imvService.GetMovieService(id);
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
                    response.MessageServiceResponse = "Pelicula no encontrada!";
                    return NotFound(response);
                }

                return Ok(response);

            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Ocurrio un inconveniente de tipo C801E!");
                return StatusCode(500, ModelState);
            }
        }


        /// <summary>
        /// Muestra peliculas de acuerdo al parámetro id de la categoria.
        /// </summary>
        /// <param name="id">Parámetro id de la categoria</param>
        /// <returns></returns>
        [HttpGet("MoviesByCategory/{id:int}")]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> GetMoviesByCategory(int id)
        {
            try
            {
                var response = await _imvService.GetMoviesByCategoryService(id);
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
                    response.MessageServiceResponse = "No se encontraron peliculas con esa categoria!";
                    return NotFound(response);
                }

                return Ok(response);

            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Ocurrio un inconveniente de tipo C805E!");
                return StatusCode(500, ModelState);
            }
        }


        /// <summary>
        /// Agrega una pelicula de acuerdo a los parámetros enviados.
        /// </summary>
        /// <param name="createMovieDto"></param>
        /// <returns></returns>
        [HttpPost("AddMovie")]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> AddMovie([FromForm] CreateMovieDto createMovieDto)
        {
            try
            {
                if (createMovieDto == null)
                {
                    return BadRequest(ModelState);
                }

                var response = await _imvService.CreateMovieService(createMovieDto);
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
                    response.MessageServiceResponse = "La pelicula ya existe!";
                    return NotFound(response);
                }

                return StatusCode(201, response);
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Ocurrio un inconveniente de tipo C802E!");
                return StatusCode(500, ModelState);
            }
        }


        /// <summary>
        /// Busca peliculas de acuerdo al parámetro nombre enviado.
        /// </summary>
        /// <param name="name">Parámetro nombre de la pelicula</param>
        /// <returns></returns>
        [HttpGet("SearchMovie")]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> SearchMovie(string name)
        {
            try
            {
                var response = await _imvService.SearchMovieService(name);
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
                    response.MessageServiceResponse = "No se encontraron coincidencias en la busqueda!";
                    return NotFound(response);
                }

                return Ok(response);

            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Ocurrio un inconveniente de tipo C806E!");
                return StatusCode(500, ModelState);
            }
        }


        /// <summary>
        /// Actualiza la información de una pelicula de acuerdo a los parámetros enviados.
        /// </summary>
        /// <param name="updateMovieDto"></param>
        /// <returns></returns>
        [HttpPut("EditMovie")]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> EditMovie([FromForm] UpdateMovieDto updateMovieDto)
        {
            try
            {
                if (updateMovieDto == null)
                {
                    return BadRequest(ModelState);
                }

                var response = await _imvService.UpdateMovieService(updateMovieDto);
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
                    response.MessageServiceResponse = "La pelicula que desea editar no existe!";
                    return NotFound(response);
                }

                return StatusCode(201, response);
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Ocurrio un inconveniente de tipo C803E!");
                return StatusCode(500, ModelState);
            }
        }


        /// <summary>
        /// Elimina una pelicula de acuerdo al parámetro id enviado.
        /// </summary>
        /// <param name="id">Parámetro id de la pelicula</param>
        /// <returns></returns>
        [HttpDelete("DeleteMovie/{id:int}")]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            try
            {
                var response = await _imvService.DeleteMovieService(id);
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
                    response.MessageServiceResponse = "Pelicula no encontrada!";
                    return NotFound(response);
                }

                return Ok(response);

            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Ocurrio un inconveniente de tipo C804E!");
                return StatusCode(500, ModelState);
            }
        }

    }
}
