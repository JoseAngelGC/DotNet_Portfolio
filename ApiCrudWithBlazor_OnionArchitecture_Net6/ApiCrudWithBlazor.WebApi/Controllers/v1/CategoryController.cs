using ApiCrudWithBlazor.Core.Abstraction.BasicHelpers.ApiControllersResponses;
using ApiCrudWithBlazor.CoreAbstractions.InputPorts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiCrudWithBlazor.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class CategoryController : BaseApiCategoryController
    {
        public CategoryController(ICategoryInputPortsService inputPortsService, 
            IControllerResponsesBasicsHelpersService responsesBasicsHelpersService) 
            : base(inputPortsService, responsesBasicsHelpersService)
        {
        }

        [HttpGet("Categories")]
        public async Task<IActionResult> GetCategoriesAsync()
        {
            try
            {
                var aplicationResponse = await _inputPortsService.GetAllCategoriesAsync();
                return await _responsesBasicsHelpersService.CustomResponseBasicHelperAsync(aplicationResponse, aplicationResponse.StatusResponse);
            }
            catch (Exception)
            {
                var exceptionResponse = await _responsesBasicsHelpersService.ExceptionResponseBasicHelperAsync();
                return await Task.FromResult(StatusCode(StatusCodes.Status500InternalServerError, exceptionResponse));
            }

        }
    }
}
