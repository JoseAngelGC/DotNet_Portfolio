using ApiCrudAndAngular.CoreAbstractions.Helpers.ApiControllers.Responses;
using ApiCrudAndAngular.CoreAbstractions.InputPorts.DepartmentInputPorts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiCrudAndAngular.WebApi.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class BaseDepartmentController : ControllerBase
    {
        protected readonly IDepartmentQueriesInputPortsService _departmentQueriesInputPortsService;
        protected readonly IDepartmentNewRecordInputPortsService _departmentNewRecordInputPortsService;
        protected readonly IDepartmentChangesRecordInputPortsService _departmentChangesRecordInputPortsService;
        protected readonly IControllerBasicResponsesHelpersService _controllerResponsesHelpersService;
        public BaseDepartmentController(IDepartmentQueriesInputPortsService departmentQueriesInputPortsService, IDepartmentNewRecordInputPortsService departmentNewRecordInputPortsService, IDepartmentChangesRecordInputPortsService departmentChangesRecordInputPortsService, IControllerBasicResponsesHelpersService controllerResponsesHelpersService)
        {
            _departmentQueriesInputPortsService = departmentQueriesInputPortsService;
            _departmentNewRecordInputPortsService = departmentNewRecordInputPortsService;
            _departmentChangesRecordInputPortsService = departmentChangesRecordInputPortsService;
            _controllerResponsesHelpersService = controllerResponsesHelpersService;
        }
    }
}
