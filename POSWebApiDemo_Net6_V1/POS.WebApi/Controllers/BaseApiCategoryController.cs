using Microsoft.AspNetCore.Mvc;
using POS.Application.Interfaces.CategoryServices.Commands.RemoveItem;
using POS.Application.Interfaces.CategoryServices.Commands.SaveItem;
using POS.Application.Interfaces.CategoryServices.Commands.UpdateItem;
using POS.Application.Interfaces.CategoryServices.Queries.GetItem;
using POS.Application.Interfaces.CategoryServices.Queries.GetLists;
using POS.Infraestructure.Helpers.WebApi.Controllers.Commons.Responses;

namespace POS.WebApi.Controllers
{
    
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public abstract class BaseApiCategoryController : ControllerBase
    {
        protected readonly IFilteredCategoriesApplicationService _filteredCategoriesApplicationService;
        protected readonly IAllCategoriesApplicationService _allCategoriesApplicationService;
        protected readonly ICategoryByIdApplicationService _categoryByIdApplicationService;
        protected readonly IAddCategoryApplication _addCategoryApplicationService;
        protected readonly IAlterCategoryApplication _alterCategoryApplicationService;
        protected readonly IDeleteCategoryApplication _deleteCategoryApplicationService;
        protected readonly GenericCustomResult _genericCustomResult;

        public BaseApiCategoryController(IFilteredCategoriesApplicationService filteredCategoriesApplicationService, IAllCategoriesApplicationService allCategoriesApplicationService, ICategoryByIdApplicationService categoryByIdApplicationService, IAddCategoryApplication addCategoryApplicationService, IAlterCategoryApplication alterCategoryApplicationService, IDeleteCategoryApplication deleteCategoryApplicationService)
        {
            _filteredCategoriesApplicationService = filteredCategoriesApplicationService;
            _allCategoriesApplicationService = allCategoriesApplicationService;
            _categoryByIdApplicationService = categoryByIdApplicationService;
            _addCategoryApplicationService = addCategoryApplicationService;
            _alterCategoryApplicationService = alterCategoryApplicationService;
            _deleteCategoryApplicationService = deleteCategoryApplicationService;
            _genericCustomResult = new GenericCustomResult();
        }
    }
}
