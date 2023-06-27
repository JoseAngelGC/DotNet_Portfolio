using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreBasicCRUD.ApplicationServices.Interfaces.CategoryServices.Queries;
using StoreBasicCRUD.ControllersCoreStructure.ControllerHelpers.Collectors.Exceptions;
using StoreBasicCRUD.ControllersCoreStructure.ControllerHelpers.Collectors.ResultResponses.Interfaces;

namespace StoreBasicCRUD.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class CategoryController : BaseApiCategoryController
    {
        public CategoryController(IGetAllCategoriesService allCategoriesService, IGenericCustomResultResponse genericCustomResultResponse) : base(allCategoriesService, genericCustomResultResponse)
        {
        }

        [HttpGet("Categories")]
        public async Task<IActionResult> GetCategoriesListAsync()
        {
            try
            {
                var response = await _allCategoriesService.ResponseAsync();
                return await _genericCustomResultResponse.ResponseAsync(response, response.StatusResponse);
            }
            catch (Exception)
            {
                var response = await ControllerExceptionBasicCollectorStatic.ResponseAsync();
                return await Task.FromResult(StatusCode(StatusCodes.Status500InternalServerError, response));
            }
        }
    }
}
