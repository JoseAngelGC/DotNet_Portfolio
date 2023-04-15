using Microsoft.AspNetCore.Mvc;
using POS.Application.Interfaces.CategoryServices.Commands.RemoveItem;
using POS.Application.Interfaces.CategoryServices.Commands.SaveItem;
using POS.Application.Interfaces.CategoryServices.Commands.UpdateItem;
using POS.Application.Interfaces.CategoryServices.Queries.GetItem;
using POS.Application.Interfaces.CategoryServices.Queries.GetLists;
using POS.Infraestructure.Helpers.WebApi.Controllers.Commons.Collectors.Exceptions;
using POS.Infraestructure.SupportDtos.Application.RequestsDtos.CategoryRequestsDtos;
using POS.Infraestructure.SupportDtos.Commons.Requests;

namespace POS.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class CategoryController : BaseApiCategoryController
    {
        public CategoryController(IFilteredCategoriesApplicationService filteredCategoryListApplicationService, IAllCategoriesApplicationService allCategoriesApplicationService, ICategoryByIdApplicationService categoryByIdApplicationService, IAddCategoryApplication saveCategoryItemApplicationService, IAlterCategoryApplication updateCategoryItemApplicationService, IDeleteCategoryApplication removeCategoryItemApplicationService) : base(filteredCategoryListApplicationService, allCategoriesApplicationService, categoryByIdApplicationService, saveCategoryItemApplicationService, updateCategoryItemApplicationService, removeCategoryItemApplicationService)
        {
        }

        [HttpPost("Categories")]
        public async Task<IActionResult> GetCategoriesList([FromBody] GenericFiltersRequestDto filters)
        {
            try
            {
                var response = await _filteredCategoriesApplicationService.GetListAsync(filters);
                return await _genericCustomResult.ResponseAsync(response, response.StatusResponse);
            }
            catch (Exception)
            {
                var response = await ControllerExceptionCollectorStatic.ResponseAsync(3100);
                return await Task.FromResult(StatusCode(StatusCodes.Status500InternalServerError, response));
            }
        }


        [HttpGet("CategoriesSelect")]
        public async Task<IActionResult> GetCategoriesSelect()
        {
            try
            {
                var response = await _allCategoriesApplicationService.GetItemsAsync();
                return await _genericCustomResult.ResponseAsync(response, response.StatusResponse);
            }
            catch (Exception)
            {
                var response = await ControllerExceptionCollectorStatic.ResponseAsync(3200);
                return await Task.FromResult(StatusCode(StatusCodes.Status500InternalServerError, response));
            }
        }


        [HttpGet("Item/{id:int}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            try
            {
                var response = await _categoryByIdApplicationService.GetItemAsync(id);
                return await _genericCustomResult.ResponseAsync(response, response.StatusResponse);
            }
            catch (Exception)
            {
                var response = await ControllerExceptionCollectorStatic.ResponseAsync(3300);
                return await Task.FromResult(StatusCode(StatusCodes.Status500InternalServerError, response));
            }

        }

        [HttpPost("SaveCategory")]
        public async Task<IActionResult> RegisterCategory([FromBody] CategoryRequestDto requestDto)
        {
            try
            {
                var response = await _addCategoryApplicationService.SaveItemAsync(requestDto);
                return await _genericCustomResult.ResponseAsync(response, response.StatusResponse);
            }
            catch (Exception)
            {
                var response = await ControllerExceptionCollectorStatic.ResponseAsync(4300);
                return await Task.FromResult(StatusCode(StatusCodes.Status500InternalServerError, response));
            }

        }

        [HttpPut("UpdateCategory/{id:int}")]
        public async Task<IActionResult> UpdateCategory(int id, [FromBody] CategoryRequestDto requestDto)
        {
            try
            {
                var response = await _alterCategoryApplicationService.UpdateItemAsync(id, requestDto);
                return await _genericCustomResult.ResponseAsync(response, response.StatusResponse);
            }
            catch (Exception)
            {
                var response = await ControllerExceptionCollectorStatic.ResponseAsync(5300);
                return await Task.FromResult(StatusCode(StatusCodes.Status500InternalServerError, response));
            }

        }

        [HttpDelete("DeleteCategory/{id:int}")]
        public async Task<IActionResult> DeleteCategory(int id, [FromBody] CategoryRequestDto requestDto)
        {
            try
            {
                var response = await _deleteCategoryApplicationService.RemoveItemAsync(id, requestDto);
                return await _genericCustomResult.ResponseAsync(response, response.StatusResponse);
            }
            catch (Exception)
            {
                var response = await ControllerExceptionCollectorStatic.ResponseAsync(6300);
                return await Task.FromResult(StatusCode(StatusCodes.Status500InternalServerError, response));
            }
        }
    }
}
