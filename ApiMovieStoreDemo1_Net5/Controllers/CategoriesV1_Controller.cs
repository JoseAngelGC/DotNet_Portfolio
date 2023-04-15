using ApiMovieStoreDemo1_Net5.Models.Dtos.CategoryDtos;
using ApiMovieStoreDemo1_Net5.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ApiMovieStoreDemo1_Net5.Controllers
{
    [Authorize]
    [Route("api/v{version:apiVersion}/Categories")]
    [ApiController]
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "ApiCategories_v1")]

    public class CategoriesV1_Controller : ControllerBase
    {
        private readonly ICategoryService _ictService;
        public CategoriesV1_Controller(ICategoryService icategoryService)
        {
            _ictService = icategoryService;
        }

        /// <summary>
        /// Muestra todas las categorias.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> GetCategories()
        {
            try
            {
                var response = await _ictService.GetCategoriesService();
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
                ModelState.AddModelError("", "Ocurrio un inconveniente de tipo C900E!");
                return StatusCode(500, ModelState);
            }

        }

        /// <summary>
        /// Muestra una categoria de acuerdo al parámetro id enviado.
        /// </summary>
        /// <param name="id">Parámetro id de la categoria</param>
        /// <returns></returns>
        [HttpGet("Category/{id:int}")]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> GetCategory(int id)
        {
            try
            {
                var response = await _ictService.GetCategoryService(id);
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
                    response.MessageServiceResponse = "Categoria no encontrada!";
                    return NotFound(response);
                }

                return Ok(response);

            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Ocurrio un inconveniente de tipo C901E!");
                return StatusCode(500, ModelState);
            }

        }

        /// <summary>
        /// Agrega una categoria de acuerdo a los parámetros enviados.
        /// </summary>
        /// <param name="createCategoryDto">Parámetros necesarios para agregar la categoria</param>
        /// <returns></returns>
        [HttpPost("AddCategory")]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> AddCategory([FromBody] CreateCategoryDto createCategoryDto)
        {
            try
            {
                if (createCategoryDto == null)
                {
                    return BadRequest(ModelState);
                }

                var response = await _ictService.CreateCategoryService(createCategoryDto);
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
                    response.MessageServiceResponse = "La categoria ya existe!";
                    return NotFound(response);
                }

                return StatusCode(201, response);
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Ocurrio un inconveniente de tipo C902E!");
                return StatusCode(500, ModelState);
            }
        }

        /// <summary>
        /// Actualiza una categoria de acuerdo a los parámetros enviadas.
        /// </summary>
        /// <param name="updateCategoryDto">Parámetros necesarios para actualizar la categoria</param>
        /// <returns></returns>
        [HttpPut("EditCategory")]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> EditCategory([FromBody] UpdateCategoryDto updateCategoryDto)
        {
            try
            {
                if (updateCategoryDto == null)
                {
                    return BadRequest(ModelState);
                }

                var response = await _ictService.UpdateCategoryService(updateCategoryDto);
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
                    response.MessageServiceResponse = "No existe la categoria que desea editar!";
                    return NotFound(response);
                }

                return StatusCode(201, response);
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Ocurrio un inconveniente de tipo C903E!");
                return StatusCode(500, ModelState);
            }

        }

        /// <summary>
        /// Elimina una categoria de acuerdo al parámetro id enviado.
        /// </summary>
        /// <param name="id">Parámetro id de la categoria</param>
        /// <returns></returns>
        [HttpDelete("DeleteCategory/{id:int}")]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest(ModelState);
                }

                var response = await _ictService.DeleteCategoryService(id);
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
                    response.MessageServiceResponse = "No existe la categoria que desea eliminar!";
                    return NotFound(response);
                }

                return StatusCode(204, response);
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Ocurrio un inconveniente de tipo C904E!");
                return StatusCode(500, ModelState);
            }
        }
    }
}
