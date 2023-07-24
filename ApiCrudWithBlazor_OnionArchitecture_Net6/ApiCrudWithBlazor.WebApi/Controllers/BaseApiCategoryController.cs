using ApiCrudWithBlazor.Core.Abstraction.BasicHelpers.ApiControllersResponses;
using ApiCrudWithBlazor.CoreAbstractions.InputPorts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiCrudWithBlazor.WebApi.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class BaseApiCategoryController : ControllerBase
    {
        protected readonly ICategoryInputPortsService _inputPortsService;
        protected readonly IControllerResponsesBasicsHelpersService _responsesBasicsHelpersService;
        public BaseApiCategoryController(ICategoryInputPortsService inputPortsService, IControllerResponsesBasicsHelpersService responsesBasicsHelpersService)
        {
            _inputPortsService = inputPortsService;
            _responsesBasicsHelpersService = responsesBasicsHelpersService;
        }
    }
}
