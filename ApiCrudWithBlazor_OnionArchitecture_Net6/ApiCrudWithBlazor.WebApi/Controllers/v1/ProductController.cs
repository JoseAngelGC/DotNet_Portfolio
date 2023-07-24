using ApiCrudWithBlazor.Core.Abstraction.BasicHelpers.ApiControllersResponses;
using ApiCrudWithBlazor.CoreAbstractions.CoreEntities.Dtos.RequestsDtos;
using ApiCrudWithBlazor.CoreAbstractions.InputPorts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiCrudWithBlazor.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class ProductController : BaseApiProductController
    {
        public ProductController(IProductInputPortsService productiInputPortsService, 
            IControllerResponsesBasicsHelpersService responsesBasicsHelpersService) 
            : base(productiInputPortsService, responsesBasicsHelpersService)
        {
        }

        [HttpPost("Products")]
        public async Task<IActionResult> GetProductsAsync(CommonFiltersRequestDto filters)
        {
            try
            {
                var response = await _productiInputPortsService.GetFilteredProductsAsync(filters);
                return await _responsesBasicsHelpersService.CustomResponseBasicHelperAsync(response, response.StatusResponse);
            }
            catch (Exception)
            {
                var exceptionResponse = await _responsesBasicsHelpersService.ExceptionResponseBasicHelperAsync();
                return await Task.FromResult(StatusCode(StatusCodes.Status500InternalServerError, exceptionResponse));
            }
        }

        [HttpGet("Product/{id:int}")]
        public async Task<IActionResult> GetProductByIdAsync(int id)
        {
            try
            {
                var response = await _productiInputPortsService.GetProductByIdAsync(id);
                return await _responsesBasicsHelpersService.CustomResponseBasicHelperAsync(response, response.StatusResponse);
            }
            catch (Exception)
            {
                var exceptionResponse = await _responsesBasicsHelpersService.ExceptionResponseBasicHelperAsync();
                return await Task.FromResult(StatusCode(StatusCodes.Status500InternalServerError, exceptionResponse));
            }
        }

        [HttpPost("RegisterProduct")]
        public async Task<IActionResult> SaveProductAsync([FromBody] ProductRequestDto request)
        {
            try
            {
                var response = await _productiInputPortsService.CreateProductAsync(request);
                return await _responsesBasicsHelpersService.CustomResponseBasicHelperAsync(response, response.StatusResponse);
            }
            catch (Exception)
            {
                var exceptionResponse = await _responsesBasicsHelpersService.ExceptionResponseBasicHelperAsync();
                return await Task.FromResult(StatusCode(StatusCodes.Status500InternalServerError, exceptionResponse));
            }
        }

        [HttpPut("EditProduct/{id:int}")]
        public async Task<IActionResult> EditProductAsync(int id, [FromBody] ProductRequestDto request)
        {
            try
            {
                var response = await _productiInputPortsService.EditProductAsync(id, request);
                return await _responsesBasicsHelpersService.CustomResponseBasicHelperAsync(response, response.StatusResponse);
            }
            catch (Exception)
            {
                var exceptionResponse = await _responsesBasicsHelpersService.ExceptionResponseBasicHelperAsync();
                return await Task.FromResult(StatusCode(StatusCodes.Status500InternalServerError, exceptionResponse));
            }
        }

        [HttpDelete("DeleteProduct/{id:int}")]
        public async Task<IActionResult> DeleteProductAsync(int id)
        {
            try
            {
                var response = await _productiInputPortsService.DeleteProductAsync(id);
                return await _responsesBasicsHelpersService.CustomResponseBasicHelperAsync(response, response.StatusResponse);
            }
            catch (Exception)
            {
                var exceptionResponse = await _responsesBasicsHelpersService.ExceptionResponseBasicHelperAsync();
                return await Task.FromResult(StatusCode(StatusCodes.Status500InternalServerError, exceptionResponse));
            }
        }
    }
}
