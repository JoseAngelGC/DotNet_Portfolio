using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreBasicCRUD.ApplicationServices.Interfaces.CategoryServices.Queries;
using StoreBasicCRUD.ControllersCoreStructure.ControllerHelpers.Collectors.ResultResponses.Interfaces;

namespace StoreBasicCRUD.WebApi.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class BaseApiCategoryController : ControllerBase
    {
        protected readonly IGetAllCategoriesService _allCategoriesService;
        protected readonly IGenericCustomResultResponse _genericCustomResultResponse;
        public BaseApiCategoryController(IGetAllCategoriesService allCategoriesService, IGenericCustomResultResponse genericCustomResultResponse)
        {
            _allCategoriesService = allCategoriesService;
            _genericCustomResultResponse = genericCustomResultResponse;
        }
    }
}
