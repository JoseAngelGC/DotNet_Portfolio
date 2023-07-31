using ApiCrudAndAngular.CoreAbstractions.CoreEntities.Dtos.DepartmentDtos;
using ApiCrudAndAngular.CoreAbstractions.CoreEntities.Dtos.OutputPortDtos.Responses;
using ApiCrudAndAngular.Entities.ApiCrud.SQLServer.SPs.POCOs;


namespace ApiCrudAndAngular.CoreAbstractions.InputPorts
{
    public interface IDepartmentInputPortsService
    {
        Task<QueryResponseDto<IQueryable<Department>>> GetAllDepartmentsAsync();
        Task<QueryResponseDto<Department>> GetDepartmentByNameAsync(string name);
        Task<CommandResponseDto> NewDepartmentAsync(DepartmentRequestDto departmentRequestDto);
        Task<CommandResponseDto> UpdateDepartmentAsync(DepartmentDto departmentPivotDto);
        Task<CommandResponseDto> DeleteDepartmentAsync(DepartmentDto departmentPivotDto);
    }
}
