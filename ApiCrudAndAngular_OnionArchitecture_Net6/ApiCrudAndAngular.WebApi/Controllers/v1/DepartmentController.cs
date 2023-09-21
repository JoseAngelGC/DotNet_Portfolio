using ApiCrudAndAngular.CoreAbstractions.CoreEntities.Dtos.DepartmentDtos;
using ApiCrudAndAngular.CoreAbstractions.Helpers.ApiControllers.Responses;
using ApiCrudAndAngular.CoreAbstractions.InputPorts.DepartmentInputPorts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiCrudAndAngular.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class DepartmentController : BaseDepartmentController
    {
        public DepartmentController(IDepartmentQueriesInputPortsService departmentQueriesInputPortsService, 
            IDepartmentNewRecordInputPortsService departmentNewRecordInputPortsService, 
            IDepartmentChangesRecordInputPortsService departmentChangesRecordInputPortsService, 
            IControllerBasicResponsesHelpersService controllerResponsesHelpersService) 
            : base(departmentQueriesInputPortsService, departmentNewRecordInputPortsService, 
                  departmentChangesRecordInputPortsService, controllerResponsesHelpersService)
        {
        }

        [HttpGet("Departments")]
        public async Task<IActionResult> GetDepartmentsAsync()
        {
            try
            {
                var aplicationServiceResponse = await _departmentQueriesInputPortsService.GetDepartmentsAsync();
                return await _controllerResponsesHelpersService.CustomResponseBasicHelperAsync(aplicationServiceResponse, aplicationServiceResponse.StatusResponse);
            }
            catch (Exception)
            {
                var exceptionResponse = await _controllerResponsesHelpersService.ExceptionResponseBasicHelperAsync();
                return await Task.FromResult(StatusCode(StatusCodes.Status500InternalServerError, exceptionResponse));
            }
        }


        [HttpGet("Department/{id:int}")]
        public async Task<IActionResult> GetDepartmentAsync(int id)
        {
            try
            {
                var aplicationServiceResponse = await _departmentQueriesInputPortsService.GetDepartmentByIdAsync(id);
                return await _controllerResponsesHelpersService.CustomResponseBasicHelperAsync(aplicationServiceResponse, aplicationServiceResponse.StatusResponse);
            }
            catch (Exception)
            {
                var exceptionResponse = await _controllerResponsesHelpersService.ExceptionResponseBasicHelperAsync();
                return await Task.FromResult(StatusCode(StatusCodes.Status500InternalServerError, exceptionResponse));
            }
        }


        [HttpPost("RegisterDepartment")]
        public async Task<IActionResult> AddDepartmentAsync([FromBody] DepartmentRequestDto request)
        {
            try
            {
                var aplicationServiceResponse = await _departmentNewRecordInputPortsService.RegisterDepartmentAsync(request);
                return await _controllerResponsesHelpersService.CustomResponseBasicHelperAsync(aplicationServiceResponse, aplicationServiceResponse.StatusResponse);
            }
            catch (Exception)
            {
                var exceptionResponse = await _controllerResponsesHelpersService.ExceptionResponseBasicHelperAsync();
                return await Task.FromResult(StatusCode(StatusCodes.Status500InternalServerError, exceptionResponse));
            }
        }


        [HttpPut("EditDepartment/{id:int}")]
        public async Task<IActionResult> EditProductAsync(int id, [FromBody] DepartmentRequestDto request)
        {
            try
            {
                var aplicationServiceResponse = await _departmentChangesRecordInputPortsService.EditDepartmentAsync(id, request);
                return await _controllerResponsesHelpersService.CustomResponseBasicHelperAsync(aplicationServiceResponse, aplicationServiceResponse.StatusResponse);
            }
            catch (Exception)
            {
                var exceptionResponse = await _controllerResponsesHelpersService.ExceptionResponseBasicHelperAsync();
                return await Task.FromResult(StatusCode(StatusCodes.Status500InternalServerError, exceptionResponse));
            }
        }


        [HttpDelete("DeleteDepartment/{id:int}")]
        public async Task<IActionResult> DeleteProductAsync(int id, [FromBody] DepartmentRequestDto request)
        {
            try
            {
                var aplicationServiceResponse = await _departmentChangesRecordInputPortsService.RemoveDepartmentAsync(id, request);
                return await _controllerResponsesHelpersService.CustomResponseBasicHelperAsync(aplicationServiceResponse, aplicationServiceResponse.StatusResponse);
            }
            catch (Exception)
            {
                var exceptionResponse = await _controllerResponsesHelpersService.ExceptionResponseBasicHelperAsync();
                return await Task.FromResult(StatusCode(StatusCodes.Status500InternalServerError, exceptionResponse));
            }
        }
    }
}
