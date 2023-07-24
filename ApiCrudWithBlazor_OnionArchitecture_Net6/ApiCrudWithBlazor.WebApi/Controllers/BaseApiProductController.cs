using ApiCrudWithBlazor.Core.Abstraction.BasicHelpers.ApiControllersResponses;
using ApiCrudWithBlazor.CoreAbstractions.InputPorts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiCrudWithBlazor.WebApi.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class BaseApiProductController : ControllerBase
    {
        protected readonly IProductInputPortsService _productiInputPortsService;
        protected readonly IControllerResponsesBasicsHelpersService _responsesBasicsHelpersService;
        public BaseApiProductController(IProductInputPortsService productiInputPortsService, IControllerResponsesBasicsHelpersService responsesBasicsHelpersService)
        {
            _productiInputPortsService = productiInputPortsService;
            _responsesBasicsHelpersService = responsesBasicsHelpersService;
        }
    }
}
